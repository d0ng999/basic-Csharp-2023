using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{
    class Cat 
    // internal이 없는 클래스는 public이 필수
    // public이 없거나 안쓰이면 기본적으로 private이다.
    // private이라도 같은 cs13_class안에 있어서 접근 가능
    {
        #region < 생성자 > 
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Cat()
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }

        /// <summary>
        /// 사용자 지정 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color = "흰색", sbyte age = 1)
        {
            Name = name;
            Color = color;
            Age = age;
        }


        #endregion

        #region < 멤버변수 - 속성 > // region & endregion 영역
        public string Name; // 고양이 이름
        public string Color; // 고양이 색상
        public sbyte Age; // 고양이 나이 0 ~ 255까지
        #endregion

        #region < 멤버메서드 - 기능 >
        public void Meow() // private 이 default
        {
            Console.WriteLine("{0} - 야옹!", Name, Color, Age);
            // {0}은 Name, Color, Age에서 0번 째인 Name만!
        }

        public void Run()
        {
            Console.WriteLine("{0} 달린다.", Name, Color, Age);
        }
        #endregion
    }
    internal class Program 
    // internal은 지금 현재 코드에서는 다 쓸 수 있음
    {
        static void Main(string[] args)
        {
            #region < hellokitty, nero >
            Cat hellokitty = new Cat();
            // 생성자(클래스라는 이름의 hellokitty 객체를 생성)
            // 클래스 자체는 같은 코드 내에 있어서 접근 가능하지만
            // Cat 클래스 내에 메서드에는 접근이 불가능하다(private)
            hellokitty.Name = "헬로키티";
            hellokitty.Color = "흰색";
            hellokitty.Age = 50;
            hellokitty.Meow();
            hellokitty.Run();

            // 객체를 생성하면서 속성 초기화
            Cat nero = new Cat() {
                Age = 27,
                Color = "검은색",
                Name = "검은고양이 네로"
            }; // {}를 쓰면 클래스 내에 메서드를 바로 초기화 가능

            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.",
                hellokitty.Name, hellokitty.Color, hellokitty.Age);
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.",
                nero.Name, nero.Color, nero.Age);
            #endregion

            Cat yaongi = new Cat();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.",
                yaongi.Name, yaongi.Color, yaongi.Age);

            Cat norangi = new Cat("노랑이", "노란색");
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.",
                norangi.Name, norangi.Color, norangi.Age);
            ///  종료자는 안 써도 된다. 왜? 
            ///  Garbage Collector가 있어서 알아서 프로그램의
            ///  종료 시점에 쓰레기로 버려진다.
            

        }
    }
}
