using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs19_Interface
{
    interface ILogger
    {
        void WriteLog(string log);
    }

    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params object[] args); 
        // args 다중 파라미터
    }

    class ConsolLooger : ILogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string format, params object[] args)
        {
            string message = string.Format(format, args);
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string log)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class Car
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public void Stop()
        {
            Console.WriteLine("정지!!");
        }
    }

    interface IHoverable
    {
        void Hover();
    }

    interface IFlyable
    {
        void Fly(); // 날다
    }

    // 클래스는 다중 상속이 불가능하다. 없다.
    // 근데 인터페이스를 사용하면 다중 상속과 비슷하게 사용가능
    class FlyHoverCar : Car, IFlyable, IHoverable
    {
        public void Fly()
        {
            Console.WriteLine("날아요");
        }

        public void Hover()
        {
            Console.WriteLine("달려요");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsolLooger();
            logger.WriteLog("안녕!~~!~!~");

            IFormattableLogger logger2 = new ConsoleLogger2 ();
            logger2.WriteLog("{0} x {1} = {2}", 6, 7, 6 * 7);
        }
    }
}
