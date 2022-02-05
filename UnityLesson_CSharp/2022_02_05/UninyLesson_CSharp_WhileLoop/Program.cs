using System;

namespace UninyLesson_CSharp_WhileLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*// while 의 구조
            while (조건)
            {
                조건이 참일때 반복할 내용
            }
            // 무한루프 (while의 조건이 항상 참일 경우)
            // 절대 코드에 있어서는 안되는 존재
            while (true)
            {

            }*/
            string[] arr_PersonName = new string[3];
            arr_PersonName[0] = "김아무개";
            arr_PersonName[1] = "홍길동";
            arr_PersonName[2] = "동";

            int length = arr_PersonName.Length;
            int count = 0;
            //되도록이면 숫자는 넣지 않는다. 그러면 나중에 수정할때 골치아파진다.(매직넘버)
            while (count < length)
            {
                Console.WriteLine(arr_PersonName[count]);
                count++;
            }

            count= 0;
            while (true)
            {

                if(count<length)
                {
                    Console.WriteLine(arr_PersonName[count]);
                }
                else
                {
                    break;
                }
                count++;
            }
         
        }
    }
}