using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIsolation
{
    /// <summary>
    /// 接口隔离原则
    /// </summary>
    class Class1
    {

    }

    interface IComputerLearn
    {
        void Tolearn();
    }

    interface IComputerWork
    {
        void ToWork();
    }

    interface IComputerBeFun
    {
        void ToBeFun();
    }

    class Audlt
    {
        private IComputerWork myWork;
        private IComputerBeFun myFun;

        public void UseComputer()
        {
            myWork.ToWork();
            myFun.ToBeFun();
        }

    }

    class Child
    {
        private IComputerLearn myLearn;

        public void UseComputer()
        {
            myLearn.Tolearn();
        }
    }
}
