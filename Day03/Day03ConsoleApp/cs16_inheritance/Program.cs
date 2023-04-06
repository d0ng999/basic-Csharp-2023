using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{
    class Base // 기반 또는 부모 클래스
        // 상속받은 이후 Base의 Name, Color, Age를 새로 만들거나 하지 않음
        // 자식클래스에서 상속받을려면 private은 안써야 함
    {
        protected string Name;
        private string Color; // 상속을 할꺼면 Private이 아닌 Protected를 사용
        public int Age;

        public Base(string Name, string Color, int Age)
            // 같은 클래스 내에서 사용되기 때문에 private, protected, public 상관없음
        {
            this.Name   = Name;
            this.Color = Color; 
            this.Age = Age;
            Console.WriteLine("{0}.Base()", Name);
        }

        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor() // 자기 클래스만 private이 접근 가능하지만
            // 자식 클래스는 안됨
        {
            Console.WriteLine("{0}.Base() {1}", Name, Color);
        }
    }

    class Child : Base // private Color를 여기서는 쓸 수없어서 에러!
    {
        public Child(string Name, string Color, int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White",15);
            b.BaseMethod();
            b.GetColor();

            Child c = new Child("NameC", "Black", 16);
            c.BaseMethod();
            c.ChildMethod();
            c.GetColor(); // 부모클래스의 함수를 받아서 실행된다.
            // c에서 Color에 접근이 불가!! -- Color는 현재 부모 클래스꺼를 사용!
        }
    }
}
