using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Stage1 : MonoBehaviour
{
    Rigidbody2D rigid;

    public float speed;

    float h;
    float v;




    //�����̵����� �ƴ��� Ȯ�����ִ� ����
    bool isHorisonMove;

    //�ٶ󺸰� �ִ� ���� ���� ���� ����
    Vector3 dirVec;

    //��ȣ�ۿ� ��ü ����
    public GameObject scanObject;

    //�ִϸ��̼�
    Animator anim;

    //���� �޴��� ����
    public DialogManager manager;

    //�ߺ� ��ȭ ����
    public int count;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Move Value
        //Input.GetAxisRaw()�� ���� ���� �� ����
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");     //����
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");       //����


        //Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");


        //Check Horizontal Move
        if (hDown || vUp)
            isHorisonMove = true;
        else if (vDown || hUp)
            isHorisonMove = false;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left; 
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //ù��° �̺�Ʈ�� ��ų� �����̽��� ����
        if (count == 0 && scanObject != null || Input.GetButtonDown("Jump") && scanObject != null)
        {

            
            manager.Action(scanObject);
            count = 1;



            
        }



    }

    void FixedUpdate()
    {
        //�÷��̾� �̵� (����� �� �̵�: �밢�� �Ұ�)

        Vector2 moveVec = isHorisonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray�� ���� Object ����
        Debug.DrawRay(rigid.position, dirVec * 1.2f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
