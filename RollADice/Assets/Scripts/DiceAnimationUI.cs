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
    public delegate void AnimationFinishedEvent();

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("DiceVectorDark");
    }

    // coroutine ���ΰ� ���θ� ȣ���ϴ� ��� 
    // ���� ���� : ������
    // ���α׷��� �ּҴ��� : ���μ���, �� ���μ����� �̷�� �ִ� �ּ� ������ �������� �Ѵ�.
    // �ٸ� �����忡�� ������ ��ó�� ���̴� ��. 
    public IEnumerator E_DiceAnimation(int diceValue, DicePlayManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;
        while (elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;
            int tmpIdx = Random.Range(0, sprites.Length);
            diceAnimationImage.sprite = sprites[tmpIdx];
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
