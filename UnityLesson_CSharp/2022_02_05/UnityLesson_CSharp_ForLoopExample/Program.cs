using System;

// Orc 객체를 10마리 만들고 
// Orc들의 인스턴스는 Orc 타입 배열에 넣어준다.
// 각 오크의 이름은 "오크0", "오크1", "오크2"......"오크9"
// 오크에게 isResting 멤버변수값은 랜덤으로 넣어준다.
// 각 오크가 쉬고있는지 확인해서 쉬고있다면 점프하도록 한다.

namespace UnityLesson_CSharp_ForLoopExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc[] arr_Orc = new Orc[10];            // 10개의 오크를 담을 수 있는 배열을 생성
            /*Orc orc1 = new Orc(); 이거와는 다르다.이건 인스턴스화도 한거다.new키워드를 썼다고 생성한 것이 아니다.*/

            int length = arr_Orc.Length;            // 따로 지역변수를 지정하는 이유.
            // 디버깅 방식 차이를 쉽게 확인하기 위해 따로 빼놓는 것이다. 
            // 가시성은 물론이며 한줄씩 디버깅하며 문제를 찾아낼때도 쉽게 찾을 수 있다.
            // 이러면 for문에 문제가 있는지 변수 선언에 문제가 있는지 쉽게 찾을 수 있다.
            for (int i = 0; i < arr_Orc.Length; i++)
            {
                arr_Orc[i] = new Orc(); // 오크 생성, 여기서 인스턴스화한다. 생성자
                arr_Orc[i].name = "오크"+i; // 또는 $"오크{i}";
                Console.WriteLine(arr_Orc[i].name);
            }

            // IsResting 랜덤 세팅
            for (int i = 0; i < length; i++)
            {
                arr_Orc[i].Isresting = GetRandomBool();
            }
            

            for (int i = 0; i < length; i++)
            {
                if (arr_Orc[i].Isresting)
                {
                    arr_Orc[i].Jump();
                }
            }
        }
        
        static private bool GetRandomBool()
        {
            Random random = new Random(); // 디버깅을 용이하게 하기 위해  
            int randomInt = random.Next(0, 2); // minValue ~ maxValue - 1 
            bool randomBool = Convert.ToBoolean(randomInt);
            /*bool randomint = random.Next(0, 2) < 1;            // 정수형 반환
            bool randomFloat = random.Next(0f, 1f) < 0.5f;       // 실수형 반환*/
            return randomBool;
                       
        }
        
        public class Orc
        {
            public string name;
            public float height;
            public float weight;
            public int age;
            public char Gender;
            public bool Isresting;

            public void Smash()
            {
                Console.WriteLine($"{name}(이)가 휘둘렀다.");
            }

            public void Jump()
            {
                Console.WriteLine($"{name}(이)가 점프했다.");
            }
        }
    }
}