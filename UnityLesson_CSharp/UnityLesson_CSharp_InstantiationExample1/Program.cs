using System;

namespace UnityLesson_CSharp_InstantiationExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1 = new Orc();
            orc1.name = "상급오크";
            orc1.height = 240.2f;
            orc1.weight = 200;
            orc1.age = 140;
            orc1.Gender = '남';
            orc1.Isresting = false;

            Orc orc2 = new Orc();
            orc2.name = "하급오크";
            orc2.height = 140.4f;
            orc2.weight = 120;
            orc2.age = 60;
            orc2.Gender = '여';
            orc2.Isresting = true;

            if(orc1.Isresting)
            {
                orc1.Smash();
                orc1.Jump();
            }
            else
            {
                Console.WriteLine($"{orc1.name}(이)가 바쁘다.");
            }
            
            if (orc2.Isresting)
            {
                orc2.Smash();
                orc2.Jump();
            }
            else
            {
                Console.WriteLine($"{orc2.name}(이)가 바쁘다.");
            }
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