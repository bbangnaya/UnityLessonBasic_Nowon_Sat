using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // �Ķ���͸� ������ �Լ� ����
    public bool GetBool(string name) =>
        animator.GetBool(name);
    public float GetFloat(string name) =>
        animator.GetFloat(name);
    public int GetInt(string name) =>
            animator.GetInteger(name);
    // Ʈ���ŷ� ���� ����
    // ���⼭ name�� animator�� statemachine�� �Ķ�����̴�.
    // bool, float, int, trigger �� ������ �� �ִ� �Լ� 4�� ����
    public void SetBool(string name, bool value) =>
        animator.SetBool(name, value);//
    public void SetFloat(string name, float value) =>
        animator.SetFloat(name, value);
    public void SetInt(string name, int value) =>
        animator.SetInteger(name, value);
    public void SetTrigger(string name) =>
        animator.SetTrigger(name);

    // �ִϸ��̼� ���� ���� Ȯ�� �Լ�
    public bool IsClipPlaying(string name)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(name) ? true : false;
    }

    // Ư�� �ִϸ��̼� ��� �ð��� �˼� �ִ�.
    public float GetClipTime(string name)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if(ac.animationClips[i].name == name)
                return ac.animationClips[i].length;
        }// �̷��� �ݺ����� update���� �ǽð����� ���� �ȵǱ⿡ awake���� �ʱ�ȭ�� ���̴�.
        return -1.0f;
    }

}
