using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{
    /// <summary>
    /// 封装例子
    /// </summary>
    class PackageExample
    {
    }

    public class ATM
    {
        private Client GetUser(string userID)
        {
            throw new NotImplementedException();
        }

        private bool IsValidUser(Client user)
        {
            throw new NotImplementedException();
        }

        private int GetCash(int money)
        {
            throw new NotImplementedException();
        }

        public void CashProcess(string userID,int money)
        {
            Client tmpUser = GetUser(userID);
            if (IsValidUser(tmpUser))
            {
                GetCash(money);
            }
            else
            {
                Console.Write("你不是合法用户");
            }
        }

    }


    /// <summary>
    /// 用户类
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value ?? string.Empty;
            }
        }

        /// <summary>
        /// 用户年龄
        /// </summary>
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 150)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("年龄信息不正确");
                }
            }

        }

        /// <summary>
        /// 用户密码
        /// </summary>
        private string password;

        private string firstName;
        private string secondName;


        public string WholeName => firstName + secondName;

    }

    public class TestPackage
    {
        void Testpack()
        {
            var xw = new Client();
            xw.Age = 1000;
        }
    }
}
