using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public int branch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(branch==1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Stage04_Main_2");
            }
        }
        else if(branch==2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Epilogue");
            }
        }
        
    }
}
