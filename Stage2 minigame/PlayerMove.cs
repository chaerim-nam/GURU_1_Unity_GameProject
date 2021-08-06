using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //매니저 변수
    public GameManager gameManager;

    //최대속력
    public float maxSpeed;
    public float jumpPower;

    //물리 기반 움직임
    Rigidbody2D rigid;

    //collider 변수
    CapsuleCollider2D capsulecollider;

    //왼쪽으로 좌우대칭
    SpriteRenderer spriteRenderer;

    //애니메이션
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //1초에 50회 돌아감
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //Stop Speed: 손을 떼면 속력을 줄인다.
        if (Input.GetButtonUp("Horizontal"))
        {
            //normalized: 벡터 크키를 1로 만든 상태 (단위벡터)
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3)      //Abs: 절대값
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    //지속적인 키 업데이트 (꾹 누르고 있는 것), 1초에 20회 돌아감
    private void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        //Max Speed
        //Right Max Speed
        if (rigid.velocity.x > maxSpeed)             //velocity: 리지드바디의 현재 속도
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        //Left Max Speed
        else if (rigid.velocity.x < maxSpeed * (-1))  //왼쪽으로 움직이는 것은 음수니까
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        //Landing Platform
        //RayCast: 오브젝트 검색을 위해 Ray를 쏘는 방식
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));    //아래로 초록색 빔을 표시한다.

            //RayCastHit: Ray에 닿은 오브젝트
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            //빔에 맞은 물체가 있으면 isJumping 상태가 아니다.
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJumping", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //몬스터보다 위에 있음 + 아래로 낙하 중 = 밟음
            if(rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)   //Attack
            {
                OnAttack(collision.transform);
            }
            else
                OnDamaged(collision.transform.position);
        }
    }

    //버블 아이템
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //Point
            gameManager.stagePoint += 100;

            //Deactive Item
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag=="Finish")
        {
            //Finish
            gameManager.Clear();
        }
    }

    //몬스터의 죽음 관련 함수 호출
    void OnAttack(Transform enemy)
    {
        //Point
        gameManager.stagePoint += 100;

        //Reaction Force
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //Enemy Die
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.OnDamaged();
    }

    //공격을 받았을 때, 무적 상태 함수
    void OnDamaged(Vector2 targetPos)
    {
        //Health Down
        gameManager.HealthDown();

        //Change Layer (Immortal Active)
        gameObject.layer = 11;

        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 15, ForceMode2D.Impulse);

        //무적 시간 결정
        Invoke("OffDamaged", 3);
    }

    //무적 해제 함수
    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {
        //Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Sprite Flip Y
        spriteRenderer.flipY = true;

        //Collider Disable
        capsulecollider.enabled = false;

        //Die Effect Jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

    }
}
