using System;
// Switch-case에 적합한 형태
// 각 요소들이 동시에 일어나는 경우가 없는 상황에 적합한 형태
// 특히 FSM( Finite State Machine ). 어떤 동작을 하는데 있어서 순서가 엉키면 안되는 곳에서 쓰임. 대부분 기계
// 예를 들어  동작하는 데에 있어 순서가 꼬임을 방지하기 위해 FSM을 이용해 방지한다. 열거

enum e_PlayerState
{
    Idle,               // int형 ...00000000(...은 24자리)
    Attack,             // ...00000001
    Jump,               // ...00000010
    Walk,               // ...00000011
    Run,                // ...00000100
    Dash,               // ...00000101
    Home,               // ...00000110
    //DashAttack = Attack | Dash, // 돌진하면서 공격을 만들려 했지만 ...00000101 Dash와 똑같음...
    DashAttack,
}
// 각 요소들이 동시에 일어나는 경우가 있는 상황에 적합한 형태
[Flags] // Tostring() 속성을 참조할때 중복되는 모든 요소들에 대해 표현이 가능합니다.(문자열로 형변환이 가능)
enum e_PlayerTypeFlags
{
    Idle = 0,           // ...00000000
    Attack = 1 << 0,    // ...00000001
    Jump = 1 << 1,      // ...00000010
    Walk = 1 << 2,      // ...00000100
    Run = 1 << 3,       // ...00001000
    Dash = 1 << 4,      // ...00010000
    Home = 1 << 5,      // ...00100000
    //DashAttack = Attack | Dash, // 하지만 ...00010001는 합체가 가능. 중복이 없으므로 모든 경우의 수를 만들 수 있다.
    JumpAttack = Jump | Attack,
}

namespace UnityLesson_CSharp_EnumAndSwitchCase
{
    internal class Program
    {
        static e_PlayerState createMotion = (e_PlayerState)4; // 초기화.()안에 있는 것이 타입이고 
        // int형이나 float형이나 모두  32비트. 하지만 32비트 중에 누가 int인지 float인지는 모른다. 
        // 
        // casting. 자료형 변환. (e_PlayerState)1 이라 치면 공격
        // Casting 캐스팅
        // 비트정보 그대로 들고와서 타입만 변경시킴
        static void Main(string[] args)
        {
            //Enum-bit
            e_PlayerTypeFlags flags = e_PlayerTypeFlags.Jump | e_PlayerTypeFlags.Attack;
            Console.WriteLine(flags);


            Warrior warrior = new Warrior();
            Console.WriteLine("생성할 전사의 이름을 입력하세요:");
            warrior.name = Console.ReadLine();          // 입력받는 명령어 Console.ReadLine()

            //if문
            if (createMotion == e_PlayerState.Idle)
            {
                // do nothing
            }
            else if (createMotion == e_PlayerState.Attack)
            {
                warrior.Attack();
            }
            else if (createMotion == e_PlayerState.Jump)
            {
                warrior.Jump();
            }
            else if (createMotion == e_PlayerState.Walk)
            {
                warrior.Walk();
            }
            else if (createMotion == e_PlayerState.Run)
            {
                warrior.Run();
            }
            else if (createMotion == e_PlayerState.Dash)
            {
                warrior.Dash();
            }
            else if (createMotion == e_PlayerState.Home)
            {
                warrior.Home();
            }
            else
            {
                Console.WriteLine("어 상태가 이상한데");
            }

            // switch - case 분기
            /* switch (경우의 수 매개변수)
             {
                 case 경우:
                 이 경우에 실행할 내용
                     break;
                 case 경우2:
                     이 경우에 실행할 내용
                     break;
                 default:
             }*/

            // switch-case 분기
            switch (createMotion)           //다른데클릭안하고 enter치면 자동완성
            {
                case e_PlayerState.Idle:
                    // do nothing
                    break;
                case e_PlayerState.Attack:
                    warrior.Attack();
                    break;
                case e_PlayerState.Jump:
                    warrior.Jump();
                    break;
                case e_PlayerState.Walk:
                    warrior.Walk();
                    break;
                case e_PlayerState.Run:
                    warrior.Run();
                    break;
                case e_PlayerState.Dash:
                    warrior.Dash();
                    break;
                case e_PlayerState.Home:
                    warrior.Home();
                    break;
                default:
                    Console.WriteLine("전사는 그런거 할줄 몰라요.");
                    break;
            }

            // switch - tap - 매개변수입력 - 엔터

            // 전사에게 동작 명령하기
            Console.Write("전사에게 명령을 내려 주세요");
            string motionInput = Console.ReadLine();
            /*e_PlayerState motion = (e_PlayerState)Enum.Parse(typeof(e_PlayerState), motionInput);           // Enum클래스에 접근해서 parse라는 함수.자료형 변환과정
            switch (motion)           //다른데클릭안하고 enter치면 자동완성
            {
                case e_PlayerState.Idle:
                    // do nothing
                    break;
                case e_PlayerState.Attack:
                    warrior.Attack();
                    break;
                case e_PlayerState.Jump:
                    warrior.Jump();
                    break;
                case e_PlayerState.Walk:
                    warrior.Walk();
                    break;
                case e_PlayerState.Run:
                    warrior.Run();
                    break;
                case e_PlayerState.Dash:
                    warrior.Dash();
                    break;
                case e_PlayerState.Home:
                    warrior.Home();
                    break;
                default:
                    Console.WriteLine("전사는 그런거 할줄 몰라요.");
                    break;
            }*/

            /*e_PlayerState motion;
            bool isparsed = Enum.Parse(motionInput, motion);
            if (isparsed)
            {
                switch (motion)           //다른데클릭안하고 enter치면 자동완성
                {
                    case e_PlayerState.Idle:
                        // do nothing
                        break;
                    case e_PlayerState.Attack:
                        warrior.Attack();
                        break;
                    case e_PlayerState.Jump:
                        warrior.Jump();
                        break;
                    case e_PlayerState.Walk:
                        warrior.Walk();
                        break;
                    case e_PlayerState.Run:
                        warrior.Run();
                        break;
                    case e_PlayerState.Dash:
                        warrior.Dash();
                        break;
                    case e_PlayerState.Home:
                        warrior.Home();
                        break;
                    default:
                        Console.WriteLine("전사는 그런거 할줄 몰라요.");
                        break;
                }
            }*/

            Console.ReadLine();
        }
    }

    public class Warrior
    {
        public string name;
        public void Attack()
        {
            Console.WriteLine($"{name}(이)가 공격함");
        }
        public void Jump()
        {
            Console.WriteLine($"{name}(이)가 점프함");
        }
        public void Walk()
        {
            Console.WriteLine($"{name}(이)가 걷는다");
        }
        public void Run()
        {
            Console.WriteLine($"{name}(이)가 달림");
        }
        public void Dash()
        {
            Console.WriteLine($"{name}(이)가 돌진함");
        }
        public void Home()
        {
            Console.WriteLine($"{name}(이)가 귀환함");
        }
    }
}