using System;

namespace UnityLesson_CSharp_ForLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*for (인덱스용 변수를 선언하고 초기화; for문을 실행할 조건; 루프가 한번 실행될때마다 마지막에 실행할 문장)// 인덱스용 변수를 선언하고 초기화 
            {
                반복 수행시 실행할 내용 
            }*/
            string[] arr_PersonName = new string[3];
            arr_PersonName[0] = "김아무개";
            arr_PersonName[1] = "홍길동";
            arr_PersonName[2] = "동";

            int length = arr_PersonName.Length;

            for (int i = 0; i < length; i++)
            {
                Console .WriteLine(arr_PersonName[i]);
            }
            // 김아무개만 출력을 하고 싶다. 김아무개의 인텍스 규칙은 3m.



            // 모든 배열 요소를 검색하는 예시
            for (int i = 0; i < length; i++)
            {
                if (arr_PersonName[i] == "김아구매")
                {
                    Console.WriteLine(arr_PersonName[i]);
                }

            }
            // 인덱스 규칙을 활용한 예시
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(arr_PersonName[i]);
            }

        }
    }
}
