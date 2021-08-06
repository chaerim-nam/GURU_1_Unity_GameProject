using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundExplosion; 
    AudioSource myAudio;
    public static SoundManager instance;  

    public static object soundManager { get; internal set; }

    void Awake() 
    {
        if (SoundManager.instance == null) 
        {
            SoundManager.instance = this; 
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); 
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion); 
    }
    void Update()
    {

    }
}

