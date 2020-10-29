using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace 安全性1
{
    class Program
    {
        private CngKey _aliceKeySignature;
        private byte[] _alicePubKeyBlob;

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }


        public void Run() {
            InitAliceKeys();
            byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
            byte[] aliceSignature = CreateSignature(aliceData, _aliceKeySignature);
            Console.WriteLine($"Alice created signature:{Convert.ToBase64String(aliceSignature)}");
            if (VerfySignature(aliceData, aliceSignature, _alicePubKeyBlob))
            {
                Console.WriteLine($"Alice 验证成功");
            }
        }



        private void InitAliceKeys() {
            _aliceKeySignature = CngKey.Create(CngAlgorithm.ECDsaP521);
            
            _alicePubKeyBlob = _aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
        }

        public byte[] CreateSignature(byte[] data, CngKey key) {
            byte[] signature;
            using (var signingAlg=new ECDsaCng(key))
            {
                signature = signingAlg.SignData(data);
                signingAlg.Clear();
                return signature;
            }
        }

        public bool VerfySignature(byte[] data, byte[] signature, byte[] pubKey) {
            bool retValue = false;
            using (CngKey key = CngKey.Import(pubKey, CngKeyBlobFormat.GenericPublicBlob))
            using (var signingAlg=new ECDsaCng(key))
            {
                retValue = signingAlg.VerifyData(data, signature);
                signingAlg.Clear();
            }
            return retValue;
        }

    }
}
