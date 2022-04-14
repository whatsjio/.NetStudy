using System;
using System.Collections.Generic;
using System.Text;

namespace OOPrinciple
{
    interface IDBAction
    {
        void Add();
    }

    class DbManager : IDBAction
    {
        public void Add()
        {
            throw new NotImplementedException();
        }
    }

    class DbManagerProxy: IDBAction
    {
        private IDBAction dbManager;

        public DbManagerProxy(IDBAction dbAction)
        {
            dbManager = dbAction;
        }

        public void Add()
        {
            //伪代码
            if (GetPermission("id") == "add")
            {
                dbManager.Add();
            }
        }

        public string GetPermission(string id)
        {
            return String.Empty;
        }

    }

    class DbClient
    {
        public static void Start()
        {
            IDBAction DbManager = new DbManagerProxy(new DbManager());
            DbManager.Add();
        }
    }
}
