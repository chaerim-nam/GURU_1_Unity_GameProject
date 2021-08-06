using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //점수 변수
    public int stagePoint;

    //HP 변수
    public int health;

    //플레이어 변수
    public PlayerMove player;

    //UI 변수
    public Image[] UIhealth;
    public Text UIPoint;
    public GameObject RestartBtn;

    void Update()
    {
        //점수 UI 표시
        UIPoint.text = stagePoint.ToString();

        if (health == 0)
        {
            Time.timeScale = 0;

            //Retry Button UI
            RestartBtn.SetActive(true);

            //All Health UI Off
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);

            //Player Die Effect
            player.OnDie();
  
        }
    }

    public void Clear()
    {
        //Player Control Lock
        Time.timeScale = 0;

        //Result UI
        Debug.Log("게임 클리어!");

        //Restart Button UI
        RestartBtn.SetActive(true);
        Text btnText = RestartBtn.GetComponentInChildren<Text>();
        btnText.text = "Clear!";
        RestartBtn.SetActive(true);

        //다음 스테이지로 이동

    }

    public void HealthDown()
    {
        if (health >= 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);      //HP 감소 UI 표시
        }
       
    }

    //낙하 시 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어 Reposition
        if (collision.gameObject.tag == "Player")
        {
            if (health > 1) {
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = new Vector3(-15, -0.5f, -1);
            }

            //HP 감소
            HealthDown();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage03_Main_1");
        Time.timeScale = 1;
    }
}
