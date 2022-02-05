using System;
using System.Collections.Generic;
namespace UninyLesson_CSharp_Collection //동적배열
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------
            // List
            // ------------------------------------------------------
            List<int> _list=new List<int>(); // <T> 는 타입이 한가지만 된다는 뜻, <T,K> 는 여러 타입,List도 클래스이다. 인스턴스화하는 것은 똑같고 괄호기호만 <>로 바뀌었다.
            _list.Add(3);
            _list.Add(2);
            _list.Add(1);
            _list.Add(0);
            _list.Add(3);

            // 0번째 인덱스부터 탐색하고 ( 추가한 순서 - 1 ), 첫번째로 매개변수와 같은 요소를 발견하면 삭제.
            // 삭제 성공시 true 반환, 아니면 false 반환

            _list.Remove(3);
            int length = _list.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(_list[i]);
            }

            // foreach는 collection이 가지고 있는 타입의 아이템만큼
            // 반복문을 실행하면서 각 아이템을 반환해준다.
            foreach (int num in _list)  // var = 자료형,알아서 변환 //_list=인스턴스, 리스트의 요소들이 int 
            {
                Console.WriteLine(num);
            }


        }


    }
}