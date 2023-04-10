using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        private int temp;       //멤버변수
        public int Temp         //프로퍼티(속성)
        {
            get { return temp; }
            set
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10; // 제일 낮은 온도로 설정 변경
                }
                else
                {
                    temp = value;
                }
            }
        }


        // 위의 get; set; 과 비교 // 아래의 Get메서드와 Set메서는 Java에서만 사용, C#은 거의 안씀.
        public void SetTemp(int temp)
        {
            if (temp < 10 || temp >= 70)
            {
                Console.WriteLine("수온이 낮거나 높습니다. 10℃~70℃사이로 조절해 주세요.");
                //return;
                this.temp = 10;
            }
            else
            {
                this.temp = temp;
            }

        }
        public int GetTemp() { return this.temp; }
    }

    class Car
    {
        //string name;
        //string color;
        int year;
        string fuelType;
        //int door;
        //string tireType;
        //string company;
        int price;
        //string carIdNumber;
        //string carPlateNumber;

        public string Name { get; set; } // 필터링이 없으면 멤버변수 없이 프로퍼티로 대체
        public string Color { get; set; }
        //public string color;
        public int Year
        {
            get { return year; } // get => year; 람다식
            set
            {
                if (value <= 1900 || value >= 2023)
                {
                    value = 2023;
                }
                Year = value;
            }
        }

        public string FuelType
        {
            get => fuelType;
            set
            {
                if (value != "휘발유" || value != "경유")
                {
                    value = "휘발유";
                }
                fuelType = value;
            }
        }

        public int door;
        public int Door {
            get { return door; }
            set
            {
                if (value != 2 || value != 4)
                {
                    value = 4;
                }
                door = value;
            }    
        }
        public string TireType { get; set; }
        public string Company { get; set; } = "현대 자동차";
        public int Price { get => price; set => price = value; }
        public string CarIdNumber { get; set; }
        public string CarPlateNumber { get; set; }
    }

    interface IProduct
    {
        string ProductName { get; set; }

        void Produce();
    }

    class MyProduct : IProduct
    {
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public void Produce()
        {
            Console.WriteLine("{0}을 생산합니다", ProductName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Boiler Kitturami = new Boiler();
            Kitturami.SetTemp(100);
            //Console.WriteLine(Kitturami.GetTemp());

            Boiler navien = new Boiler();
            navien.Temp = 5000;
            //Console.WriteLine(navien.Temp);

            Car ionic = new Car();
            ionic.Name = "아이오닉";
            Console.WriteLine(ionic.Name);

            // 생성할 때 프로퍼티로 초기화
            Car genesis = new Car()
            {
                Name = "genesis",
                FuelType = "휘발유",
                Color = "흰색",
                Door = 4,
                TireType = "광폭타이어",
                Year = 0,
            };

            Console.WriteLine("자동차 제조회사는 {0}", genesis.Company);
            Console.WriteLine("자동차 제조년도는 {0}년", genesis.Year);

        }
    }
}