using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepcopy
{
    class SomeClass
    {
        public int SomeField1;
        public int SomeField2;

        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = this.SomeField1; // Call by Value
            newCopy.SomeField2 = this.SomeField2;

            return newCopy;
        }

        class Employee
        {
            private string Name;
            public void SetName(string Name)
            {
                this.Name = Name; 
                // 멤버변수(속성)과 메서드의 매개변수이름이 대소문자까지 완전히 똑같은 때
                // this.Name은 Employee 클래스 내에 정의된 private Name
            }
        }

        class ThisClass
        {
            int a, b,c;
            public ThisClass() // 오버로딩
            {
                this.a = 1;
            }
            public ThisClass(int b) : this() // 앞의 this.a를 호출
            {
                this.b = b;
            }

            public ThisClass(int b, int c) : this(b) // 앞의 this.b를 호출
            {
                this.c = c;
            }
        }
      

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얉은 복사 시작"); 
            // source와 target이 (주소복사) 값이 공유(!)

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;
            target.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 = {0}, s.SomeField2 = {1}",
                               source.SomeField1, source.SomeField2);
            Console.WriteLine("t.SomeField1 = {0}, t.SomeField2 = {1}",
                               target.SomeField1, target.SomeField2);

            Console.WriteLine("깊은 복사");
            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy(); // 깊은 복사, 메서드가 필요함
            t.SomeField2 = 300;
            Console.WriteLine("s.SomeField1 = {0}, s.SomeField2 = {1}",
                               s.SomeField1, s.SomeField2);
            Console.WriteLine("t.SomeField1 = {0}, t.SomeField2 = {1}",
                               t.SomeField1, t.SomeField2);
        }

    }
}
