using System;
using System.Collections.Generic;
using System.Text;

namespace OOPrinciple
{

    /// <summary>
    /// 封闭开放原则
    /// </summary>
    class BankProcessExample
    {

    }

    class Client
    {
        private string ClientType;

        public Client(string clientType)
        {
            ClientType = clientType;
        }


        /// <summary>
        /// 获取业务类型
        /// </summary>
        /// <returns></returns>
        public IBankProcess CreateProcess()
        {
            switch (ClientType)
            {
                case "存款用户":
                    return new DepositProcess();
                break;
                case "转账用户":
                    return new TransferProcess();
                    break;
            }
            return null;
        }

    }

    interface IBankProcess
    {
        void Process();
    }

    class DepositProcess : IBankProcess
    {
        public void Process()
        {
            //办理存款业务
            throw new NotImplementedException();
        }
    }

    class TransferProcess : IBankProcess
    {
        public void Process()
        {
            //办理转账业务
            throw new NotImplementedException();
        }
    }

    class DrawMoneyProcess : IBankProcess
    {
        public void Process()
        {
            //办理取款业务
            throw new NotImplementedException();
        }
    }

    class EasyBankStaff
    {
        private IBankProcess bankProc;

        public void HandleProcess(IClient client)
        {
            bankProc = client.CreateProcess();
            bankProc.Process();
        }
    }

    interface IClient
    {
        IBankProcess CreateProcess();
    }

    class DepositClient : IClient
    {
        public IBankProcess CreateProcess()
        {
            return new DepositProcess();
        }
    }

    class TransferClient : IClient
    {
        public IBankProcess CreateProcess()
        {
            return new TransferProcess();
        }
    }

    class DrawMoneyClient : IClient
    {
        public IBankProcess CreateProcess()
        {
            return new DrawMoneyProcess();
        }
    }

    class BanlProcess
    {
        public static void Start()
        {
            EasyBankStaff bankStaff = new EasyBankStaff();
            bankStaff.HandleProcess(new TransferClient());
        }
    }

}
