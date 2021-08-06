using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager03 : MonoBehaviour
{

    //UI 텍스트 변수
    public Text stateLabel;
    public GameObject Btn;

    //플레이어 게임 오브젝트 변수
    GameObject player;

    //플레이어무브 컴포넌트 변수
    PlayerMove03 playerM03;

    //싱글톤
    public static GameManager03 gm03;

    private void Awake()
    {
        if (gm03 == null)
        {
            gm03 = this;
        }
    }

    public void Clear()
    {
        Time.timeScale = 0;

        Btn.SetActive(true);
        Text btnText = Btn.GetComponentInChildren<Text>();
        btnText.text = "Clear!";
        Btn.SetActive(true);

        
    }
}
