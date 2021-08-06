using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Stage1 : MonoBehaviour
{
    Rigidbody2D rigid;

    public float speed;

    float h;
    float v;




    //수평이동인지 아닌지 확인해주는 변수
    bool isHorisonMove;

    //바라보고 있는 방향 값을 가진 변수
    Vector3 dirVec;

    //상호작용 물체 변수
    public GameObject scanObject;

    //애니메이션
    Animator anim;

    //게임 메니저 변수
    public DialogManager manager;

    //중복 대화 방지
    public int count;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Move Value
        //Input.GetAxisRaw()를 통한 방향 값 추출
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");     //수평
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");       //수직


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

        //첫번째 이벤트는 닿거나 스페이스로 변경
        if (count == 0 && scanObject != null || Input.GetButtonDown("Jump") && scanObject != null)
        {

            
            manager.Action(scanObject);
            count = 1;



            
        }



    }

    void FixedUpdate()
    {
        //플레이어 이동 (쯔끄루 식 이동: 대각선 불가)

        Vector2 moveVec = isHorisonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray를 통해 Object 감지
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
