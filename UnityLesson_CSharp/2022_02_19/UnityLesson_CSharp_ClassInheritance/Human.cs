using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Human : Creature, ITwoLeggedWalker       // interface에 커서를 갖다 데고 전구 클릭 - 인터페이스 구현을 누르면 자동으로 생성된다.
    {
        public float height;        // creature에는 없는 인간만의 고유한 멤버

        // 각 인종마다 override를 안하려면 여기서 지정을 한다.
        /*public float hs = 0.00004f;
        public float ws = 0.00002f;*/

        // overide  라고 치면 부모 클래스의 함수들 콤보상자가 뜬다. 
        // overide : 부모의 virtual 키워드가 붙은 함수를 재정의하는 키워드
        public override void Breath()       // 휴먼만의 breath 함수를 재정의
        {
            base.Breath();                  // 부모 클래스 성질 그대로 가져오기
            height += 0.00004f;
            weight += 0.00002f;

            /*height += hs;
            weight += ws;*/


        }

        public void TwoLeggedWalk()
        {
            Console.WriteLine("두발로 걷는다");
        }
    }
}
