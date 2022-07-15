using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // 파라미터를 세팅할 함수 생성
    public bool GetBool(string name) =>
        animator.GetBool(name);
    public float GetFloat(string name) =>
        animator.GetFloat(name);
    public int GetInt(string name) =>
            animator.GetInteger(name);
    // 트리거로 쓰기 위해
    // 여기서 name은 animator의 statemachine의 파라미터이다.
    // bool, float, int, trigger 를 세팅할 수 있는 함수 4개 세팅
    public void SetBool(string name, bool value) =>
        animator.SetBool(name, value);//
    public void SetFloat(string name, float value) =>
        animator.SetFloat(name, value);
    public void SetInt(string name, int value) =>
        animator.SetInteger(name, value);
    public void SetTrigger(string name) =>
        animator.SetTrigger(name);

    // 애니메이션 진행 여부 확인 함수
    public bool IsClipPlaying(string name)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(name) ? true : false;
    }

    // 특정 애니메이션 재생 시간을 알수 있다.
    public float GetClipTime(string name)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if(ac.animationClips[i].name == name)
                return ac.animationClips[i].length;
        }// 이러한 반복문은 update같이 실시간으로 돌면 안되기에 awake에서 초기화할 것이다.
        return -1.0f;
    }

}
