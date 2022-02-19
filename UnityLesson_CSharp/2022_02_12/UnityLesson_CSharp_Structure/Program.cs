using System;
// Structure (구조체)
// 멤버 변수를 가지는 타입
namespace UnityLesson_CSharp_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            warrior.stats._STR = 10;
            warrior.stats._DEX = 10;
            warrior.stats._CON = 10;
            warrior.stats._WIS = 10;
            warrior.stats._INT = 10;
            warrior.stats._REG = 10;

            Mage mage = new Mage();
            mage.stats._STR = 10;
            mage.stats._DEX = 10;
            mage.stats._CON = 10;
            mage.stats._WIS = 10;
            mage.stats._INT = 10;
            mage.stats._REG = 10;

            Warrior[] arr_Warrior = new Warrior[10];
            int length = arr_Warrior.Length;
            
            // 멤버 변수 stats의 멤버변수를 for문에서 초기화하는 방법

            for (int i = 0; i < length; i++)
            {
                arr_Warrior[i] = new Warrior();
                arr_Warrior[i].stats._STR = 10;
                arr_Warrior[i].stats._DEX = 10;
                arr_Warrior[i].stats._CON = 10;
                arr_Warrior[i].stats._WIS = 10;
                arr_Warrior[i].stats._INT = 10;
                arr_Warrior[i].stats._REG = 10;

            }
            // 위 아래랑 똑같다. 

            // 지역변수 stats을 초기화한 후 for문에서 멤버변수 stats을 초기화하는 방법
            Stats tmpStats = new Stats();
            tmpStats._STR = 10;
            tmpStats._DEX = 20;
            tmpStats._CON = 30;
            tmpStats._WIS = 40;
            tmpStats._INT = 50;
            tmpStats._REG = 60;
            for (int i = 0; i < length; i++)
            {
                arr_Warrior[i].stats = tmpStats;
            }

            // 멤버변수 stats을 초기화하는 멤버함수 SetStats을 호출하는 방법
            for (int i = 0;i < length; i++)
            {
                arr_Warrior[i].SetStats(10, 20, 30, 40, 50, 60);

            }
        }
    }
}