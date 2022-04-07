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
    // 깎일때 숫자, 게이지를 감소시켜야 한다.
    // property
    public static Player instance;
    private void Awake()
    {
        instance = this;
        hp = hpMax;
        score = 0;
    }

    // property
    private int _hp;       // 읽기만 가능, 멤버hp
    public int hp{            // 수정
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
            hpText.text = _hp.ToString();           // 문자열. 형변환 함수 호출.
            // hp는 int 형인데 숫자그대로 문자형으로 바꾼다. text에 대입하기 때문이다.
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
    // 수정을 자주해야하는 경우 property를 많이 쓴다.
    // 플레이어 스탯이나 점수는 property를 많이 쓴다. 
    public Text scoreText;

    /*    public void hurt(int damage)
        {
            hp -= damage;
            hpSlider.value = hp / hpMax;
            hpText.text = hp.ToString();
        }
    넉백일지 공격 스킬에 따른 데미지 깎는 걸 일일이 해야 한다.
     */

    /*    public void SetHP(int value)
        {

        }
        public int GetHP()
        {
            return hp;
        }*/
}
