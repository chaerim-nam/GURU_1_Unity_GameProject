using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //���� ����
    public int stagePoint;

    //HP ����
    public int health;

    //�÷��̾� ����
    public PlayerMove player;

    //UI ����
    public Image[] UIhealth;
    public Text UIPoint;
    public GameObject RestartBtn;

    void Update()
    {
        //���� UI ǥ��
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
        Debug.Log("���� Ŭ����!");

        //Restart Button UI
        RestartBtn.SetActive(true);
        Text btnText = RestartBtn.GetComponentInChildren<Text>();
        btnText.text = "Clear!";
        RestartBtn.SetActive(true);

        //���� ���������� �̵�

    }

    public void HealthDown()
    {
        if (health >= 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);      //HP ���� UI ǥ��
        }
       
    }

    //���� �� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾� Reposition
        if (collision.gameObject.tag == "Player")
        {
            if (health > 1) {
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = new Vector3(-15, -0.5f, -1);
            }

            //HP ����
            HealthDown();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage03_Main_1");
        Time.timeScale = 1;
    }
}
