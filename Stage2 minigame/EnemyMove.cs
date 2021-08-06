using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //���� ������� ������
    Rigidbody2D rigid;

    //�ൿ��ǥ�� ������ ����
    public int nextMove;

    //collider ����
    CapsuleCollider2D capsulecollider;

    //�ִϸ��̼� ����
    Animator anim;

    //��������Ʈ ����
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();

        //5�� �ڿ� Think��� �̸��� �Լ��� ����
        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));    //�Ʒ��� �ʷϻ� ���� ǥ���Ѵ�.
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));       //RayCastHit: Ray�� ���� ������Ʈ

        //���� ���� ��ü�� ������ �տ� ����������� ��
        if (rayHit.collider == null)
            Turn();
    }

    void Think()
    {
        //Set Next Active
        nextMove = Random.Range(-1, 2);

        //��������Ʈ �ִϸ��̼�
        anim.SetInteger("WalkSpeed", nextMove);

        //��������Ʈ ���� ����
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);     //Invoke(): �־��� �ð��� ���� ��, ������ �Լ��� �����ϴ� �Լ�
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();     //���� �۵� ���� ��� Invoke �Լ��� ���ߴ� �Լ�
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
