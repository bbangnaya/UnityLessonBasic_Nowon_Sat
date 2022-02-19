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
            List<int> _list=new List<int>(); // <T> 는 타입이 한가지만 된다는 뜻
                                             // <T,K> 는 여러 타입,List도 클래스이다.
                                             // 인스턴스화하는 것은 똑같고 괄호기호만 <>로 바뀌었다.
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
            /*foreach (var item in collection)
            {

            }*/
            // foreach는 collection이 가지고 있는 타입의 아이템만큼 반복문을 실행하면서
            // 각 아이템을 item에 반환해준다.
            // var = 자료형,알아서 변환
            // item = 지역변수
            // collection = 인스턴스, 리스트, 배열, 딕셔너리 대입
            // 뜻 : list에 있는 요소들을 int형 num으로 반환한다. 
            foreach (int num in _list)
            {
                Console.WriteLine(num);
            }

            List<Orc> list_Orc = new List<Orc>();
            foreach (Orc item in list_Orc)
            {

            }

            //---------------------------------
            // Dictionary
            // -------------------------------------
            // 
            Dictionary<string, string> _dic = new Dictionary<string, string>();
            _dic.Add("검사", "양손대검을 사용하여 물리공격을 하는 클래스");
            _dic.Add("마법사", "지팡이를 사용하여 마법공격을 하는 클래스");
            _dic.Add("수호자", "창과 방패를 사용하여 물리공격 및 방어 위주의 클래스");
            _dic.Remove("검사");         // 단어만 알려주면 뜻도 같이 지우겠다.

            //_dic.ContainsKey("검사");        // 검사라는 키가있으면 true 없으면 false

            bool IsSwordMasterExist = _dic.ContainsKey("검사");
            if (IsSwordMasterExist)
            {
                string tmpValue = _dic["검사"];        // 인덱스 접근. 식별자가 string이어서 (검사)
                Console.WriteLine($"검사 : {tmpValue}");
            }
            else
            {
                Console.WriteLine($"검사가 없는데요?");
            }

            // dictionary도 foreach 구문이 가능하다.
            // dictionary는 collection이고 
            // dictionary의 Keys를 가져오면 KeyCollection을 가져올 수 있고
            // dictionary의 Value를 가져오면 ValueCollection을 가져올 수 있다.
            // 즉, dictionary자체도  key, value 각각도 foreach 구문이 가능하다.

            // dictionary.Keys를 foreach 문 실행
            foreach (string sub in _dic.Keys)
            {
                string tmpValue = _dic[sub];
                Console.WriteLine($"{sub} : {tmpValue}");
            }
            // dictionary.Values 를 foreach 문 실행 value로 키 찾기 XXXX
            /*foreach (var item in collection)
            {
                //string tmpKey = _dic[sub]; // 불가
            }*/

            foreach (string sub in _dic.Values)
            {
                Console.WriteLine(sub);

            }

            // dictionary를 foreach 문 실행, key가 단어, Value가 설명.
            foreach (KeyValuePair<string, string> sub in _dic)      // sub의 타입은 KeyValuePair<string, string>로 
            {
                string tmpKey = sub.Key;                            // sub에서 멤버변수 Key와 Value를 불러온다.
                string tmpValue = sub.Value;
                Console.WriteLine($"{tmpKey} : {tmpValue}");
                
            }

            // ----------------------------------
            // Queue(List와 비슷하나, FIFO, First Input First Output체계이다. 선입선출
            // ----------------------------------
            Queue<int> _queue = new Queue<int>();   // _queue는 객체를 담고있는 인스턴스

            _queue.Enqueue(10);
            _queue.Enqueue(20);
            _queue.Enqueue(30);
            Console.WriteLine(_queue.Peek());       // 가장 앞에 있는 놈 반환
            Console.WriteLine(_queue.Dequeue());    // 10, 인덱스 없이 빼겠다. 즉, 먼저 들어온놈부터 뺀다.
            Console.WriteLine(_queue.Dequeue());    // 20
            Console.WriteLine(_queue.Dequeue());    // 30

            // ----------------------------------
            // Stack(List와 비슷하나, LIFO, Last Input First Output체계이다. 블록쌓기. 후입선출
            // ----------------------------------
            Stack<int> _stack = new Stack<int>();
            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
            Console.WriteLine(_stack.Peek());       // 제일 마지막에 있는 놈 반환(위에 있는 놈)
            Console.WriteLine(_stack.Pop());        // 위에서 부터 빼낸다.
            Console.WriteLine(_stack.Pop());
            Console.WriteLine(_stack.Pop());

        }
    }
    class Orc
    {

    }
}