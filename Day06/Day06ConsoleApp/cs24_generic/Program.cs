using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{
    #region < 일반화 클래스 >
    class MyArray<T> where T : class // 일반화 클래스
    // where T : class 사용할 타입은 무조건 클래스타입이어야 한다.
    {
        T[] array;
    }

    //class MyArray_float 이럴 필요 없음<T> 만 있으면
    //{
    //    float[] array;
    //}
    #endregion

    internal class Program
    {
        #region < 일반화 메서드 > 
        // 하나로 퉁치자!! - 일반화
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i< source.Length; i++)
            {
                target[i] = source[i]; //복사
            }
        }
        #endregion

        //static void CopyArray2(long[] source, long[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i]; //복사
        //    }
        //}
        //static void CopyArray3(float[] source, float[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i]; //복사
        //    }
        //}
        //static void CopyArray4(double[] source, double[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i]; //복사
        //    }
        //}
        static void Main(string[] args)
        {
            #region < 일반화 시키기 >
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target); // CopyArray(source, target)와 동일
            foreach (var item in target)
            {
                Console.WriteLine(item);
            }

            long[] source2 = { 2100000, 2300000, 2500000, 3300000, 5600000, 7800000 };
            long[] target2 = new long[source2.Length];

            CopyArray<long>(source2, target2);
            foreach (var item in target2)
            {
                Console.WriteLine(item);
            }
            float[] source3 = { 3.14f, 3.17f, 3.25f, 3.65f, 3.94f };
            float[] target3 = new float[source3.Length];

            CopyArray<float>(source3, target3);
            foreach (var item in target3)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region < 일반화 컬렉션 >
            // 일반화 컬렉션
            List<int> list = new List<int>();
            for (var i = 10; i > 0; i--)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.RemoveAt(3); // 7 삭제 0 -10 1 - 9 2 - 8 3 - 7

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Sort();
            
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            // 아래와 같은 일반화 컬렉션을 자주 볼 수 있음
            List<MyArray<string>> myStringArray = new List<MyArray<string>>();
            #endregion

            #region < 일반화 스택 >
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.15f);
            stFloats.Push(4.28f);
            stFloats.Push(7.24f);

            //foreach (var item in stFloats)
            //{
            //    Console.WriteLine(item);
            //} 이것도 가능하긴 함 // 아래와 동일!

            while (stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());
            }
            #endregion

            #region < 일반화 큐 >
            // 일반화 큐
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("Hello");
            qStrings.Enqueue("World");
            qStrings.Enqueue("My");
            qStrings.Enqueue("C#");

            while (qStrings.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());
            }
            #endregion

            // 일반화 딕셔너리
            Dictionary<string, int> dicNumbers = new Dictionary<string, int>();
            dicNumbers["하나"] = 1;
            dicNumbers["둘"] = 2;
            dicNumbers["셋"] = 3;
            dicNumbers["넷"] = 4;

            Console.WriteLine(dicNumbers["셋"]);
        }
    }
}
