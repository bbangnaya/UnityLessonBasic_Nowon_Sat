using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;
    private void Awake()
    {
        instance = this;
    }

    public Image diceAnimationImage; // ������ �̹����� �״�� ������ ������ �ִ�.
    /*public List<Sprite> diceAnimationSprites = new List<Sprite>();*/
    public float diceAnimationTime;
    private Sprite[] sprites;
    public delegate void AnimationFinishedEvent(int diceValue); // ���Ⱑ ��Ÿ����

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("DiceVectorDark");
        // LoadAll : Resources��� ������ �˻��� (���ϸ�)�� �ִ� <> Ÿ���� ������ �ҷ��´�.
        // DiceVectorDark ��� �̹����� �ִ� ��� sprite(30)�� �о�´�.
    }

    // coroutine ���ΰ� ���θ� ȣ���ϴ� ��� 
    // ���� ���� : ������
    // ���α׷��� �ּҴ��� : ���μ���, �� ���μ����� �̷�� �ִ� �ּ� ������ �������� �Ѵ�.
    // �ٸ� �����忡�� ������ ��ó�� ���̴� ��. 
    // �ִϸ��̼� �ڷ�ƾ

    // DicePlayManager�� ȣ���� �� �ְ� public�� �����ش�.
    public IEnumerator E_DiceAnimation(int diceValue, DicePlayManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;      // �ð����
        while (elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;  // �ð� �ɰ���
            int tmpIdx = Random.Range(0, sprites.Length);   // sprites.Length(=30)���� �׸��� ���� ����
            diceAnimationImage.sprite = sprites[tmpIdx];    // �����ε��� ������ tmpIdx�� ����
            // ������Ʈ ������ ���� ��û. �ȱ׷��� ���� �ٿ�.
            yield return new WaitForSeconds(diceAnimationTime / 10);
        }
        diceAnimationImage.sprite = sprites[diceValue - 1];


        if (finishEvent != null)
            finishEvent(diceValue);

        manager.animationCoroutine = null;

    }
    // coroutine - ���ν����忡 ������ �Ҵ�޾Ƽ� ����.
    // ��Ƽ ������ - �񵿱� �Լ� - �������÷��Ϳ� ���� 



}
