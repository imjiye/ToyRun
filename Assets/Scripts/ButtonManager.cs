using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject CanvasPause;
    private GameObject btnReStart;
    private GameObject btnContinue;
    private GameObject btnGameEnd;
    public GameObject optionbtn;

    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;
    public GameObject t6;
    public GameObject t7;
    public GameObject t8;

    public string thisScene;


    public void OpenMenu() //�޴���ư�� ���� ��� �޴��˾� Ȱ��ȭ
    {
        CanvasPause.SetActive(true);
        OnTogglePauseButton();
    }
  
    public void LoadScene(int sceneId) // �� ��ȯ
    {
        SceneManager.LoadScene(sceneId);
    }

    public void ReStart() // ����� ��ư ������ �� ���� �ٽ� �ε��ϰ� �����̰� ��
    {
        //Debug.Log("re");
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    public void Continue() // ����ϱ� ��ư ������ �޴��˾� ��Ȱ��ȭ, ���� �����̰� ��
    {
        CanvasPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameEnd() // ������ ��ư ������ ��������
    {
        Debug.Log("end");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OnTogglePauseButton()
    {
        if(Time.timeScale == 0) // �����ִٸ�
        {
            Time.timeScale = 1f; // �����ϱ�
        }
        else // �����δٸ�
        {
            Time.timeScale = 0; // ���߱�
        }
    }    

    public void OpenOption() // �ɼ� ��ư ������ �ɼ� �޴� Ȱ��ȭ
    {
        optionbtn.SetActive(true);
    }

    public  void CloseOption()
    {
        optionbtn.SetActive(false);
    }

    public void delete_btn()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OpenT2()
    {
        t2.SetActive(true);
        t1.SetActive(false);
        
    }

    public void OpenT3()
    {
        t2.SetActive(false);
        t3.SetActive(true);
    }

    public void OpenT4()
    {
        t3.SetActive(false);
        t4.SetActive(true);
    }

    public void OpenT5()
    {
        t4.SetActive(false);
        t5.SetActive(true);
    }
    public void OpenT6()
    {
        t5.SetActive(false);
        t6.SetActive(true);
    }
    public void OpenT7()
    {
        t6.SetActive(false);
        t7.SetActive(true);

    }

    public void OpenT8()
    {
        t7.SetActive(false);
        t8.SetActive(true);
    }

}
