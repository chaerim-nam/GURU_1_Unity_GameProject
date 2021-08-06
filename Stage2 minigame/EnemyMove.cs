using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //물리 기반으로 움직임
    Rigidbody2D rigid;

    //행동지표를 결정할 변수
    public int nextMove;

    //collider 변수
    CapsuleCollider2D capsulecollider;

    //애니메이션 변수
    Animator anim;

    //스프라이트 변수
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();

        //5초 뒤에 Think라는 이름의 함수를 실행
        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));    //아래로 초록색 빔을 표시한다.
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));       //RayCastHit: Ray에 닿은 오브젝트

        //빔에 맞은 물체가 없으면 앞에 낭떠러지라는 뜻
        if (rayHit.collider == null)
            Turn();
    }

    void Think()
    {
        //Set Next Active
        nextMove = Random.Range(-1, 2);

        //스프라이트 애니메이션
        anim.SetInteger("WalkSpeed", nextMove);

        //스프라이트 방향 설정
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);     //Invoke(): 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();     //현재 작동 중인 모든 Invoke 함수를 멈추는 함수
        Invoke("Think", 2);
    }

    public void OnDamaged()
    {
        //Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Sprite Flip Y
        spriteRenderer.flipY = true;

        //Collider Disable
        capsulecollider.enabled = false;

        //Die Effect Jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //Destroy
        Invoke("DeActive", 5);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
