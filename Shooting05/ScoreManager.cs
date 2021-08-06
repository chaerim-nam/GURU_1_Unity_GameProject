using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{ 
    public Text currentScoreUI;                                    
    public int currentScore;
    
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value; 
            currentScoreUI.text = " " + currentScore; 
        }
    }

    public static ScoreManager Instance = null;  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
    }

  
}
