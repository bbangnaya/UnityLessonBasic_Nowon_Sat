using System;

namespace UnityLesson_CSharp_StaticExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1 = new Orc(); // 인스턴스화
            orc1.age = 5; // 멤버변수들을 모두 초기화시킨다.
            orc1.name = "몬스터 1";
            orc1.height = 3f;
            orc1.isResting = true;
            orc1.genderChar = '남';
            

            orc1.Jump();
            orc1.Smash();
            orc1.SayAllInfo();

            Person person1 = new Person(); // 오류

            Orc.typeName = "오크타입";
            Orc.SayTypeName();
        }
    }
    public class Orc
    {
        static public string typeName;
        
        public int age; // 멤버 변수
        public float height;
        public bool isResting;
        public char genderChar;
        public string name;

        static public void SayTypeName()
        {
            Console.WriteLine(typeName); // age를 쓰면 오류, 객체화되었기 때문에
        }

        public void SayAllInfo() // 멤버 함수
        {
            Console.WriteLine($"{name}의 나이 : {age}");
            Console.WriteLine($"{name}의 키 : {height}");
        }
        public void Jump()
        {
            Console.WriteLine($"{name}(이)가 점프했다");
        }
        public void Smash()
        {
            Console.WriteLine($"{name}(이)가 휘둘렀다");
        }


    }

    static public class Person
    { 
    }
    }
}
