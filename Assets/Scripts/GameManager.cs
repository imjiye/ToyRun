using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public bool isGameover = false; // 게임 오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public Text coinText;
    
    public GameObject gameoverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트
    public Text bestScore;
    public Text myScore;
    public Text myCoin;
    public Text haveCoin;

    private int score1 = 0; // 게임 점수
    private int score2 = 0; // 게임 점수
    private int score3 = 0; // 게임 점수
    private int coin = 0; // 코인 개수

    public Slider HPbar; // 생명바

    public float maxHP = 120; // 최대 생명
    public float curHP = 120; // 현재 생명(초기값)

   

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
        
        
    }

    private void Start()
    {
        HPbar.value = maxHP;
        coin = 0;
    }

    void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        /*
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            //게임 오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        */

        if(!isGameover)
        {
            HPUpdate();
        }
    }



    public void HPUpdate()
    {
        if (curHP >= 0)
        {
            curHP -= 5 * Time.deltaTime;
            HPbar.value = (int)curHP;
        }
        else
        {
            PlayerController controller = FindObjectOfType<PlayerController>();
            controller.Die();
        }
    }

    public void Attack()
    {
        if(!isGameover)
        {
            curHP -= 10;
            SoundManager.Instance.PlaySound("hit");
        }
    }

    public void AddHP()
    {
        if(!isGameover)
        {
            if(curHP < maxHP)
            {
                curHP += 20;
            }
            else
            {
                curHP = maxHP;
            }
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        //게임오버가 아니라면 
        if(!isGameover)
        {
            //점수를 증가 
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                score1 += newScore; //게임이 진행중일때만 점수를 더하게 됨
                PlayerPrefs.SetInt("score1", score1);
                SoundManager.Instance.PlaySound("score1");
                scoreText.text = "Score : " + score1;
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                score2 += newScore; //게임이 진행중일때만 점수를 더하게 됨
                PlayerPrefs.SetInt("score2", score2);
                SoundManager.Instance.PlaySound("score2");
                scoreText.text = "Score : " + score2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                score3 += newScore; //게임이 진행중일때만 점수를 더하게 됨
                PlayerPrefs.SetInt("score3", score3);
                SoundManager.Instance.PlaySound("score3");
                scoreText.text = "Score : " + score3;
            }
            
        }

    }

    public void AddCoin(int newCoin) 
    { 
        if(!isGameover)
        {
            coin += newCoin;
            PlayerPrefs.SetInt("coin", coin);
            SoundManager.Instance.PlaySound("coin");
            coinText.text = " " + coin;
        }
    }

    //스테이지별 최고점수 저장하기
    //스테이지1
    public int Get_1BestScore()
    {
        int BS = PlayerPrefs.GetInt("1Bestscore");
        return BS;
    }

    public void Set_1BestScore(int cur_score)
    {
        if(cur_score > Get_1BestScore())
        {
            PlayerPrefs.SetInt("1Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s1+");
            bestScore.text = "1Best Score : " + cur_score;

        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 25;
            Debug.Log("s1-");
            bestScore.text = "1Best Score : " + Get_1BestScore();
        }
    }
    //스테이지2
    public int Get_2BestScore()
    {
        int BS = PlayerPrefs.GetInt("2Bestscore");
        return BS;
    }

    public void Set_2BestScore(int cur_score)
    {
        if (cur_score > Get_2BestScore())
        {
            PlayerPrefs.SetInt("2Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s2+");
            bestScore.text = "2Best Score : " + cur_score;
        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 25;
            Debug.Log("s2-");
            bestScore.text = "2Best Score : " + Get_2BestScore();
        }
    }
    //스테이지3
    public int Get_3BestScore()
    {
        int BS = PlayerPrefs.GetInt("3Bestscore");
        return BS;
    }

    public void Set_3BestScore(int cur_score)
    {
        if (cur_score > Get_3BestScore())
        {
            PlayerPrefs.SetInt("3Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s3+");
            bestScore.text = "3Best Score : " + cur_score;
        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 25;
            Debug.Log("s3-");
            bestScore.text = "3Best Score : " + Get_3BestScore();
        }
    }

    //코인저장하기
    public int Get_MyCoin()
    {
        int myc = PlayerPrefs.GetInt("Mycoin");
        return myc;
    }

    public void Set_MyCoin(int Haning_coin)
    {
        if(Haning_coin == 0)
        {
            int gmc = Get_MyCoin() - Haning_coin;
            haveCoin.text = " " + gmc;
            //Debug.Log("-");
        }
        else
        {
            PlayerPrefs.SetInt("Mycoin", Haning_coin + Get_MyCoin());
            haveCoin.text = " " + Get_MyCoin();
            //Debug.Log("+");
        }
        
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        isGameover = true; //게임오버 상태로 만듦 
        gameoverUI.SetActive(true); //게임오버 UI를 활성화 시킴
        SoundManager.Instance.PlaySound("end");


        //bsetscore 저장하고 불러내서 보여주는 부분
        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            int b = Get_1BestScore();
            int s = PlayerPrefs.GetInt("score1");
            Set_1BestScore(s);

            myScore.text = "획득 점수 : " + score1;

        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            int b = Get_2BestScore();
            int s = PlayerPrefs.GetInt("score2");

            Set_2BestScore(s);

            myScore.text = "획득 점수 : " + score2;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            int b = Get_3BestScore();
            int s = PlayerPrefs.GetInt("score3");

            Set_3BestScore(s);

            myScore.text = "획득 점수 : " + score3;

        }
        
        //지금 획득한 코인 표기
        myCoin.text = "획득 코인 : " + coin;

        //지금까지 누적한 코인 표기
        int MC = Get_MyCoin();
        int c = coin;

        Set_MyCoin(c);
    }

    /*
    private int[] BestScore = new int[5];
    private string[] BestName = new string[5];

    public void ScoreSet(int currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);

        int tmpScore = 0;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            BestScore[i] = PlayerPrefs.GetInt(i + "Bestscore");
            BestName[i] = PlayerPrefs.GetString(i + "BestName");

            while(BestScore[i] < currentScore)
            {
                tmpScore = BestScore[i];
                tmpName = BestName[i];
                BestScore[i] = currentScore;
                BestName[i] = currentName;

                PlayerPrefs.SetInt(i + "Bestscore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentScore = tmpScore;
                currentName = tmpName;
            }
        }

        for(int i = 0;i < 5;i++)
        {
            PlayerPrefs.SetInt(i + "Bestscore", BestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", BestName[i]);
        }
    }
    */
}