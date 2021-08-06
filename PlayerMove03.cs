using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove03 : MonoBehaviour
{
    Rigidbody rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    GameObject gameobject;
    public GameManager03 gameManager03;
   
    public float maxSpeed;
    public float speed = 5;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isWalking",false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);       
        transform.position += dir * speed * Time.deltaTime;

        if (rigid.velocity.x > maxSpeed) //right
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed * (-1)) //left
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Stage03_Main_2");
            //gameManager03.Clear();
        }
    }

}