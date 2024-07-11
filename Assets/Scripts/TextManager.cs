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
            Debug.LogWarning("���� �ΰ� �̻��� �Ŵ��� ����");
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
        text1.DOText("���� ������ ����?", 3f);      
    }

    public void Text2()
    {
        text2.DOText("���������� �����ϰ� ���� ������ ������!\r\n\r\n�츮�� �� ������ ��ֹ��� ���ϰ�\r\n\r\n���ΰ� ����, �����۵��� ������ �Ǵ� ������ �����̾�", 10f);
    }
    public void Text3()
    {
        text3.DOText("�̰� ü�¹پ�\r\n\r\n�ð��� �������� �پ���, ��ֹ��� �ε��ĵ� �پ���!\r\n\r\n�� �پ��� �Ǹ� ���� ������ �Ǵϱ�\r\n\r\n�������� �����鼭 ��Ƴ��ƾ� ��!!", 10f);
    }
    public void Text4()
    {
        text4.DOText("���ʿ��� ������ �ϸ鼭 ȹ���� ������ Ȯ���� �� �־�!\r\n\r\nü�¹� �ؿ��� �ʰ� ���� ������ ��� Ȯ���� �� �����ϱ�\r\n\r\n������ �޸��鼭 �ְ������� �򵵷� ����~", 10f);
    }

    public void Text5()
    {
        text5.DOText("ü���� �� �پ�� ���ӿ�������\r\n\r\n�������� �������� ��� ���ӿ����� �Ǵϱ�\r\n\r\n���ۿ� �������� �ʵ��� �����ؼ� �����ؾ� ��!", 10f);
    }
    public void Text6()
    {
        text6.DOText("���������� ���� ��ֹ��� ���ݾ� �޶�\r\n\r\n���ʺ��� Stage1, Stage2, Stage3�� ��ֹ��̾�\r\n\r\n������ �����ϰ� �Ǹ� �̰͵��� ������ �� ���ϸ� ��!", 10f);
    }
    public void Text7()
    {
        text7.DOText("���� �ڽ��ȿ� �ִ� �� ���� �������̾�! \r\n���ʺ��� ���� Stage1, 2, 3���� �� �� �־�\r\n\r\n��� �ڽ� �ȿ� �ִ� �� ���� �������̾�!\r\n\r\n���ʺ��� 10����, 50����, 100������ ���� �� �־�\r\n\r\n�Ķ� �ڽ� �ȿ� �ִ� �� ���� �����̾�!\r\n\r\n���� ������ ü���� ä���ִϱ� �޸��鼭 ���� �� ì�� �Ծ�� ��!!", 15f);
    }
    public void Text8()
    {
        text8.DOText("��������� ���ӿ� ���� �����̾�!\r\n\r\n���� ��¥�� ������ ��������?", 5f);
    }

}
