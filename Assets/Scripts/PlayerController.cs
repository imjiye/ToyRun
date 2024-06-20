using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    private int jumpCount = 0; // 누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false; // 사망 상태
    private bool isHits = false;

    private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트


    private void Start()
    {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 사용자 입력을 감지하고 점프하는 처리
        if (isDead)
        {   //사망 시 처리를 더 이상 진행하지 않고 종료
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2) // 마우스 왼쪽 버튼을 누르는 순간 && 점프 카운트가 2 미만인 경우 
        {
            //점프 횟수 증가 
            jumpCount++;

            //점프 직전 속도를 제로(0, 0)로 변경 
            playerRigidbody.velocity = Vector2.zero;
            //리지드바디 위쪽으로 힘 주기 
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            //오디오 소스 재생 
            playerAudio.Play(); // 이렇게 하면 겹쳐서 중복되는 소리가 안남(하나의 소리만 남)
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0) // 마우스 왼쪽 버튼을 떼는 순간 && 속도의 y 값이 양수라면(위로 상승중)
        {
            //현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded); // 애니메이터에 있는 불타입의 파라미터 그라운드를 작동시키는 것(true, false)
                                                  // 이걸로 OnTriggerEnter2D, OnCollisionEnter2D, OnCollisionExit2D가 자동으로 돌아가게 됨
                                                  // 매 프레임마다 확인(업데이트 함수 안에 있으니까) 

        animator.SetBool("Hits", isHits);
    }

    public void Die()
    {
        // 사망 처리
        animator.SetTrigger("Die"); // 애니메이터의 다이 트리거 파라미터를 셋 

        //오디오 소스에 할당된 오디오 클립을 해당클립으로 변경 
        playerAudio.clip = deathClip;
        //사망 효과음 재생 
        playerAudio.Play();

        // 속도를 제로(0,0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        //사망 상태를 true로 변경
        isDead = true;

        // 게임 매니저의 게임오버 처리 실행 
        GameManager.instance.OnPlayerDead(); //게임매니저 스크립트에서 만들어둔 함수를 끌고온 것 
    }


    private void OnTriggerEnter2D(Collider2D other) // is trigger를 가진 물체와 충돌했을 때 자동으로 불리는 거
    {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지(아래로 떨어지는 경우)
        if (other.tag == "Dead" && !isDead) // 충돌한 상대의 태그값이 Dead이, 아직 살아있는 경우라면 Die() 실행 
        {
            Die();
        }

        // 장애물과 부딪힌 경우
        if (other.tag == "Hit" && !isDead)
        {
            isHits = true;
            GameManager.instance.Attack();
        }

        if (other.tag == "Coin10")
        {
            GameManager.instance.AddScore(1);
            GameManager.instance.AddCoin(10);
            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }

        if (other.tag == "Coin50")
        {
            GameManager.instance.AddScore(5);
            GameManager.instance.AddCoin(50);
            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            
            //게임매니저가 싱글톤이니까 거기에 있는 AddScore()를 실행해 점수를 1점 
        }

        if (other.tag == "Coin100")
        {
            GameManager.instance.AddScore(10);
            GameManager.instance.AddCoin(100);
            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            
        }

        if (other.tag == "Score")
        {
            GameManager.instance.AddScore(100);
            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            //게임매니저가 싱글톤이니까 거기에 있는 AddScore()를 실행해 점수를 1점 
            
        }

        if(other.tag == "HPitem")
        {
            GameManager.instance.AddHP();
            SoundManager.Instance.PlaySound("life");
            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // 충돌이 끝나면
    {
        isHits = false; // 충돌 애니메이션을 끄고 다시 걷게하는거
    }



    private void OnCollisionEnter2D(Collision2D collision) // 콜라이더를 가진 물체와 충돌했을 때(is trigger가 없는 물체) 자동으로 불리는 거 
   {
       // 바닥에 닿았음을 감지하는 처리
       if(collision.contacts[0].normal.y > 0.7f) // 어떤 콜라이더랑 닿았고 충돌 표면이 위쪽을 보고 있다면 
        {
            isGrounded = true;
            jumpCount = 0;
        }
   }

   private void OnCollisionExit2D(Collision2D collision) // 어떤 콜라이더에서 떨어진 경우
   {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;

   }
}