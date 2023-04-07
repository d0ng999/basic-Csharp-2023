using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs18_override
{
    class ArmorSuite
    {
        public virtual void Init() // public virtual ...
        {
            Console.WriteLine("기본 아머슈트");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine("리펄서 비~~~임");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Init()
        {
            //base.Init();
            Console.WriteLine("미니건");
            Console.WriteLine("돌격 소총");

        }
    }

    class Parent
    {
        public void CurrentMethod()
        {
            Console.WriteLine("부모클래스 메서드");
        }
    }

    class Child : Parent
    {
        public new void CurrentMethod()
        {
            Console.WriteLine("자식클래스 메서드");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 오버라이딩 예제1 >

            Console.WriteLine("아머슈트생산");
            ArmorSuite suite = new ArmorSuite();
            suite.Init();

            Console.WriteLine("워머신 생산");
            WarMachine machine = new WarMachine();
            machine.Init();

            Console.WriteLine("아이어맨 생산");
            IronMan ironMan = new IronMan();
            ironMan.Init();

            #endregion

            Parent parent = new Parent();
            Child child = new Child();

            parent.CurrentMethod();
            child.CurrentMethod();

        }
    }
}