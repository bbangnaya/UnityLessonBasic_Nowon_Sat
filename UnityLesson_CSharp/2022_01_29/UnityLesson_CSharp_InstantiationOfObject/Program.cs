using System;

namespace UnityLesson_CSharp_InstantiationOfObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            // 점(.) 연산자 - 멤버에 접근하는 연산자
            // 객체의 멤버 변수 초기화
            person1.age = 40; // int age = 40 이랑은 다르다. 
            person1.height = 233.4f;
            person1.isResting = true;
            person1.genderChar = '여';
            person1.name = "차빼";
            // 객체의 멤버 함수 호출
            person1.SayAllInfo();

            

            Person person2 = new Person();
        }
    }
    public class Person
    {
        public int age; // 멤버 변수
        public float height;
        public bool isResting;
        public char genderChar;
        public string name;

        public void SayAllInfo() // 멤버 함수
        {
            SayAge();
            SayHeight();
            SayIsResting();
            SayGenderChar();
            SayName();
        }
        void SayAge()
        {
            Console.WriteLine($"{name}의 나이 : {age}");
        }
        void SayHeight()
        {
            Console.WriteLine($"{name}의 키 : {height}");
        }
        void SayIsResting()
        {
            Console.WriteLine(isResting);
        }
        void SayGenderChar()
        {
            Console.WriteLine(genderChar);
        }
        void SayName()
        {
            Console.WriteLine(name);
        }
    }

}
