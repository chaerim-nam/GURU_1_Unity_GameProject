using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager05 : MonoBehaviour
{
    public Text stateLabel;
    public GameObject Btn;

    GameObject player;

    PlayerMove05 playerM;

    public static GameManager05 gm;


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
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