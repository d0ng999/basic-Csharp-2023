﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    internal class Program
    {
        class MyList
        {
            int[] array;

            public MyList()
            {
                array = new int[3];
            }

            public int Length
            {
                get { return array.Length; }
            }

            // 인덱서
            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if (index >= array.Length) // 3보다 커지면
                    {
                        Array.Resize(ref array, index + 1);
                        Console.WriteLine("MyList Resized : {0}", array.Length);
                    }

                    array[index] = value; // 값 할당
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            //Console.WriteLine(array[5]); // IndexOutOfRangeException

            char[] oldString = new char[5]; 
            // 문자열의 길이를 지정해줘야하는 것(C에서만 사용)
            string curString = ""; // 문자열길이 제한 없음

            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6); // 위의 배열과 차이점(계속 추가 가능)
                         // 원소 입력에 제한이 없음
            // 여러가지 메서드
            ArrayList list2 = new ArrayList();
            list2.Add(8);
            list2.Add(4);
            list2.Add(15);
            list2.Add(10);
            list2.Add(7);
            list2.Add(2);

            foreach(var item in list2)
            {
                Console.WriteLine(item);
            }

            // list에서 데이터 삭제
            Console.WriteLine("10 삭제후");
            list2.Remove(10);
            Console.WriteLine("3번째 데이터 삭제");
            list2.RemoveAt(3);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("0 번째 위치에 7을 추가");
            list2.Insert(0, 7); // 0번째 위치에 7을 넣겠다.
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("정렬");
            list2.Sort();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }



            // ArrayList .Add(), .Insert(x, y), .Remove(x), .Sort(), .Reverse()...

            // 새로 만든 MyList
            MyList myList = new MyList();
            for (int i = 1; i <= 5; i++)
            {
                myList[i] = i * 5;
            }

            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
