using System;

namespace UnityLesson_CSharp_ClassObjectInstance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AA 객체 생성
            // new 키워드
            new AA(); // 생성자 : 클래스 이름과 똑같은 함수, 객체를 생성하고 반환. // 함수 호출 // 마우스를 올리면 AA.AA()로 앞에 AA는 클래스, 뒤에 AA는 함수다. 

            // 인스턴스화
            // 메모리 공간에 객체를 할당시킨다.
            // new AA()로 생성된 객체를 반환된 값(객체)이 AA 타입변수 aa에 할당되었다.
            // 이렇게하면 aa변수를 통해서 생성된 객체에 접근할 수가 있게 된다. 
            // 여기서 새로 생성된 객체가 할당된 aa변수를 인스턴스 라고 함

            AA aa = new AA();
        }
    }
    // AA 클래스
    // 접근 제한자
    // public       : 다른 모든 클래스에서 접근할 수가 있다.
    // private      : 다른 클래스에서 접근할 수가 없다.
    // protected    : 상속받은 클래스에서만 접근할 수가 있다.
    // internal     : 같은 어셈블리 ( 같은 프로젝트 ) 에서만 접근할 수가 있다.
    // 기본적으로 접근제한자를 명시하지 않으면 private이 기본값(디폴트).

    class AA
    {
        public AA()
        {

        }

        public AA(int a)
        {


        }
        ~AA() // 소멸자
        {


        }

    }
}
