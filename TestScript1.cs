using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript1 : MonoBehaviour
{
    BGMManager BGM;

    public int playMusicTrack;


    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
    }

    void Update()
    {
        BGM.Play(playMusicTrack);
        this.gameObject.SetActive(false);
    }


  
}
