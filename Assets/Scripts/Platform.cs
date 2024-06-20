using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    //3가지가 있기 때문에 배열로 설정한 것

    public GameObject[] coin10;
    public GameObject[] coin50;
    public GameObject[] coin100;
    public SpriteRenderer coin10rd;
    public SpriteRenderer coin50rd;
    public SpriteRenderer coin100rd;

    public GameObject[] scoreitem;
    public SpriteRenderer scoreitemrd;

    public GameObject[] HPitem;
    public SpriteRenderer HPitemrd;

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() //Awake() > OnEnable() > Start()
    {
        // 장애물의 수만큼 루프
        for (int i = 0; i < obstacles.Length; i++) //장애물의 숫자만큼 반복
        {
            // 현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0) //0, 1, 2 중에 하나가 나오는데 그게 0일 때 
            {
                obstacles[i].SetActive(true);
            }
            else //0이 안나오는 경우일 때
            {
                obstacles[i].SetActive(false);
            }
        }

        coin10rd.enabled = true;
        // 장애물의 수만큼 루프
        for (int i = 0; i < coin10.Length; i++) //장애물의 숫자만큼 반복
        {
            // 현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0) //0, 1, 2 중에 하나가 나오는데 그게 0일 때 
            {
                coin10[i].SetActive(true);
            }
            else //0이 안나오는 경우일 때
            {
                coin10[i].SetActive(false);
            }
        }

        coin50rd.enabled = true;
        for (int i = 0; i < coin50.Length; i++) //장애물의 숫자만큼 반복
        {
            // 현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0) //0, 1, 2 중에 하나가 나오는데 그게 0일 때 
            {
                coin50[i].SetActive(true);
            }
            else //0이 안나오는 경우일 때
            {
                coin50[i].SetActive(false);
            }
        }

        coin100rd.enabled = true;
        for (int i = 0; i < coin100.Length; i++) //장애물의 숫자만큼 반복
        {
            // 현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0) //0, 1, 2 중에 하나가 나오는데 그게 0일 때 
            {
                coin100[i].SetActive(true);
            }
            else //0이 안나오는 경우일 때
            {
                coin100[i].SetActive(false);
            }
        }

        scoreitemrd.enabled = true;
        // 장애물의 수만큼 루프
        for (int i = 0; i < scoreitem.Length; i++) //장애물의 숫자만큼 반복
        {
            // 현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0) //0, 1, 2 중에 하나가 나오는데 그게 0일 때 
            {
                scoreitem[i].SetActive(true);
            }
            else //0이 안나오는 경우일 때
            {
                scoreitem[i].SetActive(false);
            }
        }

        HPitemrd.enabled = true;
        for (int i = 0; i < HPitem.Length; i++)
        {
            if (Random.Range(0, 5) == 0)
            {
                HPitem[i].SetActive(true);
            }
            else
            {
                HPitem[i].SetActive(false);
            }
        }
    }

}