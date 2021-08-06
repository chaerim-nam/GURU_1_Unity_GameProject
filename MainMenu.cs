using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void OnClickLoad()
    {
        SceneManager.LoadScene("Stage1");
        StartCoroutine(LoadSceneCoroutine());
    }
    IEnumerator LoadSceneCoroutine()
    {
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Single);
    }

    public void OnClickOption()
    {

    }

}
