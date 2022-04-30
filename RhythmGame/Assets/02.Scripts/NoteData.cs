using UnityEngine;
/// <summary>
/// 특정 시간과 키에 대한 노트 데이터를  저장하기 위한 클래스
/// </summary>

// Serialize : 값을 읽어들인다음에 txt로 바꿔주는 것.

// Tip
// C#에는 값 형식과 참조형식이 있는데
// 값형식은 말그대로 값을 읽고 쓰는 형식,
// 값형식의 종류 : 일반적인 데이터 타입들(int, float, double, enum, structure 등...)
// 참조형식은 주소를 참조해서 해당 주소의 값을 읽고 쓰는 형식
// 참조형식의 종류 : 클래스, 인터페이스, 델리게이트
// 참조형식들은 기본적으로 Serialize가 안됨.
// 참조형식은 주소이기때문에 주소를 읽어들여서 txt를 바꿔줄수 없다. 껏다 키면 주소가 바뀌기 때문.
// 하지만 Serialize속성을 주면 참조형식을 Serialize시도할 때 해당 주소의 힙역역에 있는 값들을 읽어옴.
// 

[System.Serializable]   // 해당 클래스 타입의 오브젝트가 Serialize 가능하도록 해주는 속성 
public class NoteData
{
    public float time;
    public KeyCode keyCode;
}
