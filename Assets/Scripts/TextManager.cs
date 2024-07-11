using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 매니저 존재");
            Destroy(gameObject);
        }
    }

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    
    // Start is called before the first frame update
    void Start()
    {
        text1.DOText("게임 설명을 들어볼래?", 3f);      
    }

    public void Text2()
    {
        text2.DOText("스테이지를 선택하고 나면 게임이 시작해!\r\n\r\n우리가 할 게임은 장애물을 피하고\r\n\r\n코인과 과일, 아이템들을 먹으면 되는 간단한 게임이야", 10f);
    }
    public void Text3()
    {
        text3.DOText("이건 체력바야\r\n\r\n시간이 지날수록 줄어들고, 장애물에 부딪쳐도 줄어들어!\r\n\r\n다 줄어들게 되면 게임 오버가 되니까\r\n\r\n생명물약을 먹으면서 살아남아야 해!!", 10f);
    }
    public void Text4()
    {
        text4.DOText("왼쪽에는 게임을 하면서 획득한 코인을 확인할 수 있어!\r\n\r\n체력바 밑에는 너가 얻은 점수도 계속 확인할 수 있으니까\r\n\r\n열심히 달리면서 최고점수를 얻도록 힘내~", 10f);
    }

    public void Text5()
    {
        text5.DOText("체력이 다 줄어들어도 게임오버지만\r\n\r\n구멍으로 떨어지면 즉시 게임오버가 되니까\r\n\r\n구멍에 떨어지지 않도록 주의해서 게임해야 해!", 10f);
    }
    public void Text6()
    {
        text6.DOText("스테이지에 따라 장애물이 조금씩 달라\r\n\r\n왼쪽부터 Stage1, Stage2, Stage3의 장애물이야\r\n\r\n게임을 시작하게 되면 이것들을 점프로 잘 피하면 돼!", 10f);
    }
    public void Text7()
    {
        text7.DOText("빨간 박스안에 있는 건 점수 아이템이야! \r\n왼쪽부터 각각 Stage1, 2, 3에서 볼 수 있어\r\n\r\n노란 박스 안에 있는 건 코인 아이템이야!\r\n\r\n왼쪽부터 10코인, 50코인, 100코인을 얻을 수 있어\r\n\r\n파란 박스 안에 있는 건 생명 물약이야!\r\n\r\n저걸 먹으면 체력을 채워주니까 달리면서 꼭꼭 잘 챙겨 먹어야 해!!", 15f);
    }
    public void Text8()
    {
        text8.DOText("여기까지가 게임에 대한 설명이야!\r\n\r\n이제 진짜로 모험을 떠나볼까?", 5f);
    }

}
