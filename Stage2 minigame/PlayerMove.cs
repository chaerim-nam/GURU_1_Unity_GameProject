using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�Ŵ��� ����
    public GameManager gameManager;

    //�ִ�ӷ�
    public float maxSpeed;
    public float jumpPower;

    //���� ��� ������
    Rigidbody2D rigid;

    //collider ����
    CapsuleCollider2D capsulecollider;

    //�������� �¿��Ī
    SpriteRenderer spriteRenderer;

    //�ִϸ��̼�
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //1�ʿ� 50ȸ ���ư�
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //Stop Speed: ���� ���� �ӷ��� ���δ�.
        if (Input.GetButtonUp("Horizontal"))
        {
            //normalized: ���� ũŰ�� 1�� ���� ���� (��������)
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3)      //Abs: ���밪
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    //�������� Ű ������Ʈ (�� ������ �ִ� ��), 1�ʿ� 20ȸ ���ư�
    private void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        //Max Speed
        //Right Max Speed
        if (rigid.velocity.x > maxSpeed)             //velocity: ������ٵ��� ���� �ӵ�
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        //Left Max Speed
        else if (rigid.velocity.x < maxSpeed * (-1))  //�������� �����̴� ���� �����ϱ�
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        //Landing Platform
        //RayCast: ������Ʈ �˻��� ���� Ray�� ��� ���
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));    //�Ʒ��� �ʷϻ� ���� ǥ���Ѵ�.

            //RayCastHit: Ray�� ���� ������Ʈ
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            //���� ���� ��ü�� ������ isJumping ���°� �ƴϴ�.
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
            //���ͺ��� ���� ���� + �Ʒ��� ���� �� = ����
            if(rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)   //Attack
            {
                OnAttack(collision.transform);
            }
            else
                OnDamaged(collision.transform.position);
        }
    }

    //���� ������
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

    //������ ���� ���� �Լ� ȣ��
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

    //������ �޾��� ��, ���� ���� �Լ�
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

        //���� �ð� ����
        Invoke("OffDamaged", 3);
    }

    //���� ���� �Լ�
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
