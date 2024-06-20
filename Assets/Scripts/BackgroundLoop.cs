using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour
{
    private float width; // 배경의 가로 길이

    private void Awake()
    {
        // 가로 길이를 측정하는 처리
        BoxCollider2D bc = GetComponent<BoxCollider2D>(); // 박스콜라이더 컴포넌트를 불러옴 
        width = bc.size.x; // 박스콜라이더의 사이즈 필드의 x 값을 배경의 가로 길이로 사용
    }

    private void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 리셋
        if(transform.position.x <= -width) // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치 
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition()
    {
        //현재 위치에서 오른쪽으로 가로 길이 * 2만큼 이동 
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        //원래 vector3 타입인 transform.position을 vector2로 캐스팅(형변환)
        //백그라운드의 위치를 위에 새로만든 offset를 더해서 이동 
    }
}