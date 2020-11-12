using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using static System.Console;

//使用EC Diffie-Hellman 算法交换一个对称密钥
namespace ECDHellman安全例子
{
    class Program
    {
        private CngKey _aliceKey;
        private CngKey _bobKey;

        private byte[] _alicePubKeyBlob;
        private byte[] _bobPubKeyBlob;

        static void Main(string[] args)
        {
            var p = new Program();
            p.RunAsync().Wait();
            ReadLine();
        }

        public async Task RunAsync() {
            try
            {
                CreateKeys();
                byte[] encrytpedData = await AliceSendsDataAsync("This is asecret meaasge for Bob");
                await BobReceivesDataAsync(encrytpedData);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public void CreateKeys() {
            _aliceKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP521);
            _bobKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP521);
            _alicePubKeyBlob = _aliceKey.Export(CngKeyBlobFormat.EccPublicBlob);
            _bobPubKeyBlob = _bobKey.Export(CngKeyBlobFormat.EccPublicBlob);

        }


        public async Task<byte[]> AliceSendsDataAsync(string message) {
            WriteLine($"Alice sends message:{message}");
            byte[] rawData = Encoding.UTF8.GetBytes(message);
            byte[] encryptedData = null;
            using (var aliceAlgorithm = new ECDiffieHellmanCng(_aliceKey))
            using (CngKey bobPubKey=CngKey.Import(_bobPubKeyBlob,CngKeyBlobFormat.EccPublicBlob))
            {
                byte[] symmKey = aliceAlgorithm.DeriveKeyMaterial(bobPubKey);
                WriteLine("Alice creates this symmetric key with" + $"Bobs public key information:{Convert.ToBase64String(symmKey)}");
                using (var aes=new AesCryptoServiceProvider())
                {
                    aes.Key = symmKey;
                    aes.GenerateIV();
                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    using (var ms=new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            await ms.WriteAsync(aes.IV, 0, aes.IV.Length);
                            cs.Write(rawData, 0, rawData.Length);
                        }
                        encryptedData = ms.ToArray();
                    }
                    aes.Clear();
                }
            }
            WriteLine("Alice:message is encrypted:" + $"{Convert.ToBase64String(encryptedData)}");
            WriteLine();
            return encryptedData;
        }

        public async Task BobReceivesDataAsync(byte[] encryptedData) {
            WriteLine("Bob receives encrypted data");
            byte[] rawData = null;
            var aes = new AesCryptoServiceProvider();
            int nBytes = aes.BlockSize>>3;
            byte[] iv = new byte[nBytes];
            for (int i = 0; i < iv.Length; i++)
            {
                iv[i] = encryptedData[i];
            }
            using (var bobAlgorithm = new ECDiffieHellmanCng(_bobKey))
            using (CngKey alicePubkey=CngKey.Import(_alicePubKeyBlob,CngKeyBlobFormat.EccPublicBlob))
            {
                byte[] symmKey = bobAlgorithm.DeriveKeyMaterial(alicePubkey);
                WriteLine("Bob creates this symmetric key with " + $"Alices public key information:{Convert.ToBase64String(symmKey)}");
                aes.Key = symmKey;
                aes.IV = iv;
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (MemoryStream ms=new MemoryStream())
                {
                    using (var cs=new CryptoStream(ms,decryptor,CryptoStreamMode.Write))
                    {
                        await cs.WriteAsync(encryptedData, nBytes, encryptedData.Length - nBytes);
                    }
                    rawData = ms.ToArray();
                    WriteLine("bob decrypts message to" + $"{Encoding.UTF8.GetString(rawData)}");
                }
                aes.Clear();
            }

        }

    }
}
