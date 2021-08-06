using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{

    static public BGMManager instance;

    public AudioClip[] clips; //πË∞Ê¿Ωæ«µÈ

    private AudioSource source;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }



    public void Play(int _PlayMusicTrack)
    {
        source.volume = 1f;
        source.clip = clips[_PlayMusicTrack];
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

   //

    IEnumerator FadeOutMusicCoroutine()
    {
        for(float i = 1.0f;  i>= 0f;  i-=0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }
//

    IEnumerator FadeInMusicCoroutine()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }
}
