using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hpMax;
    public Slider hpSlider;
    public Text hpText;
    /*private int hp;  */
    // ���϶� ����, �������� ���ҽ��Ѿ� �Ѵ�.
    // property
    public static Player instance;
    private void Awake()
    {
        instance = this;
        hp = hpMax;
        score = 0;
    }

    // property
    private int _hp;       // �б⸸ ����, ���hp
    public int hp           // ����
    {
        set
        {
            if (value > 0)
                _hp = value;
            else
            {
                _hp = 0;
                Destroy(gameObject);
            }

            _hp = value;
            hpSlider.value = (float)_hp / hpMax;
            hpText.text = _hp.ToString();           // ���ڿ�. ����ȯ �Լ� ȣ��.
        }

        get
        {

            return _hp;
        }

    }



    private int _score;

    public int score
    {
        set
        {

            _score = value;
            scoreText.text = _score.ToString();

        }

        get
        {
            return _score;

        }


    }
    // ������ �����ؾ��ϴ� ��� property�� ���� ����.
    // �÷��̾� �����̳� ������ property�� ���� ����. 
    public Text scoreText;

    /*    public void hurt(int damage)
        {
            hp -= damage;
            hpSlider.value = hp / hpMax;
            hpText.text = hp.ToString();
        }
    �˹����� ���� ��ų�� ���� ������ ��� �� ������ �ؾ� �Ѵ�.
     */

    /*    public void SetHP(int value)
        {

        }
        public int GetHP()
        {
            return hp;
        }*/
}
