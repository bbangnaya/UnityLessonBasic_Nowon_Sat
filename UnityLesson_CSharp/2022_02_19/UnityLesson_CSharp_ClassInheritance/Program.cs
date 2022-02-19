using System;
using System.Collections.Generic;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creature creature = new Creature();
            creature.Breath();
            for(int i = 0; i < 10; i++)
            {
                creature.Breath();
            }
            Console.WriteLine($"생물체 나이 : {creature.age}");
                        
            Human human = new Human();
            for (int i = 0; i < 10; i++)
            {
                human.Breath();
            }
            Console.WriteLine($"인간 나이 : {human.age}");
            Console.WriteLine($"인간 키 : {human.height}");
            Console.WriteLine($"인간 무게 : {human.weight}");

            WhiteMan whiteman = new WhiteMan();
            for (int i = 0; i < 10; i++)
            {
                whiteman.Breath();
            }
            Console.WriteLine($"백인 나이 : {whiteman.age}");
            Console.WriteLine($"백인 키 : {whiteman.height}");
            Console.WriteLine($"백인 무게 : {whiteman.weight}");

            BlackMan blackman = new BlackMan();
            for (int i = 0; i < 10; i++)
            {
                blackman.Breath();
            }
            Console.WriteLine($"흑인 나이 : {blackman.age}");
            Console.WriteLine($"흑인 키 : {blackman.height}");
            Console.WriteLine($"흑인 무게 : {blackman.weight}");

            YellowMan yellowman = new YellowMan();
            for (int i = 0; i < 10; i++)
            {
                yellowman.Breath();
            }
            Console.WriteLine($"황인 나이 : {yellowman.age}");
            Console.WriteLine($"황인 키 : {yellowman.height}");
            Console.WriteLine($"황인 무게 : {yellowman.weight}");

            Dog dog = new Dog();
            dog.tailLength = 1f;
            
            // 각 인종 20명, 2발로 걷기
            // ----------------------------------------
            // case : 각 인종에 대한 리스트 별개로 생성하기

            List<WhiteMan> whitemen = new List<WhiteMan>();     // 각 인종에 대한 리스트 별개로 생성하기
            List<BlackMan> blackmen = new List<BlackMan>();
            List<YellowMan> yellowmen = new List<YellowMan>();
            for (int i = 0; i < 20; i++)
            {
                WhiteMan tmpMan = new WhiteMan();               // WhiteMan 타입의 tmpMan을 생성. WhiteMan을 참조.
                whitemen.Add(tmpMan);                           // 리스트 whitemen에 tmpMan(=WhiteMan) 추가
            }
            for (int i = 0; i < 20; i++)
            {
                BlackMan tmpMan = new BlackMan();
                blackmen.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                YellowMan tmpMan = new YellowMan();
                yellowmen.Add(tmpMan);
            }
            foreach (var item in whitemen)
            {
                item.TwoLeggedWalk();                           // item에 리스트 whitemen 요소들에 대해 TwoLeggedWalk() 호출
            }
            foreach (var item in blackmen)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in yellowmen)
            {
                item.TwoLeggedWalk();
            }

            // WhiteMan 객체화 -> Human으로 인스턴스화
            // Human변수에 있는 Breath를 호출하면 WhiteMan에 있는 Breath가 호출됨

            // 자식 객체를 부모 클래스타입으로 인스턴스화 시키고
            // 해당 변수의 virtual 멤버 함수를 호출하면
            // 자식 객체의 override된 함수가 호출된다.


            Human testHuman = new WhiteMan();
            testHuman.Breath();
            Console.WriteLine($"{testHuman.height}{testHuman.weight}");

            // case : 위 성질을 이용하여 부모클래스(Human) 리스트 하나만 생성
            List<Human> humen = new List<Human>();
            for (int i = 0; i < 20; i++)                // for문이 한 줄 밖에 없다.
            {
                Human tmpHuman1 = new WhiteMan();
                humen.Add(tmpHuman1);
                Human tmphuman2 = new BlackMan();
                humen.Add(tmphuman2);
                Human tmphuman3 = new YellowMan();
                humen.Add(tmphuman3);
            }
            foreach (var item in humen)
            {
                item.TwoLeggedWalk();
            }

            // 인터페이스 인스턴스화 예시
            ITwoLeggedWalker iTwoLeggedWalker = new WhiteMan();                 // 인스턴스 ITwoLeggedWalker 타입의 iTwoLeggedWalker에 WhiteMan 참조. 
            iTwoLeggedWalker.TwoLeggedWalk();                                   // iTwoLeggedWalker에 TwoLeggedWalk 호출
            // 스택영역의 데이터를 관리하는데 효율적이다. 
            // case : 인터페이스로 인스턴스화시키는 방법
            List<ITwoLeggedWalker> walkers = new List<ITwoLeggedWalker>();      // 인터페이스를 walkers라는 리스트로 변환 
            for (int i = 0; i < 20; i++)
            {
                ITwoLeggedWalker tmpWalker1 = new WhiteMan();               // 지역변수 tmpWalker1에 WhiteMan 참조
                walkers.Add(tmpWalker1);                                    // walkers라는 리스트에 tmpWalker1(WhiteMan) 추가
                ITwoLeggedWalker tmpWalker2 = new BlackMan();               // 지역변수 tmpWalker1에 WhiteMan 참조
                walkers.Add(tmpWalker2);                                    // walkers라는 리스트에 tmpWalker2(=BlackMan) 추가
                ITwoLeggedWalker tmpWalker3 = new YellowMan();              // 지역변수 tmpWalker1에 WhiteMan 참조
                walkers.Add(tmpWalker3);                                    // walkers라는 리스트에 tmpWalker3(YellowMan) 추가
            }
            foreach (var item in walkers)
            {
                item.TwoLeggedWalk();                                       // walkers라는 리스트의 멤버변수 TwoLeggedWalk 호출 
            }
        }
    }
}
