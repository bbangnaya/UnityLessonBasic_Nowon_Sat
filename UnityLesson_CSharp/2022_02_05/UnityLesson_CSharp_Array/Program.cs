using System;

namespace UnityLesson_CSharp_Array
{
    internal class Program
    {
        // array
        // 형태 : 자료형[]
        // 자료형이 '정적'으로 나열되어있는 형태
        // 크기를 한번 정해놓으면 바꿀 수 없다.
        // 동적할당도 있으니 참고

        static int[] arr_TestInt = new int[5];
        static float[] arr_TestFloat = new float[3];
        static float[] arr_TestFloat2 = { 1.0f, 2.0f, 3.0f, 4.0f };// 값을 아예 할당함
        static string[] arr_TestString = new string[3];
        static int[,] arr_Test= new int[5,5];
        static void Main(string[] args)
        {
            arr_TestInt[0]= 5;
            arr_TestInt[1]= 4;
            arr_TestInt[2]= 3;
            arr_TestInt[3]= 2;
            arr_TestInt[4]= 1;
            
            Console.WriteLine(arr_TestInt); //타입출력

            Console.WriteLine(arr_TestInt[0]);
            Console.WriteLine(arr_TestInt[1]);
            Console.WriteLine(arr_TestInt[2]);
            Console.WriteLine(arr_TestInt[3]);
            Console.WriteLine(arr_TestInt[4]);

            arr_TestFloat[2] = 1.0f;
            Console.WriteLine(arr_TestFloat[1]);
            Console.WriteLine(arr_TestFloat[2]);
            arr_TestString[1] = "안녕";
            Console.WriteLine(arr_TestString[1]);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr_Test[i, j] = i + j;
                    Console.WriteLine(" "+ arr_Test[i,j]);
                }
            }
            
            
        }
    }
}
