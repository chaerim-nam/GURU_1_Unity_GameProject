using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;


    void Start()
    {
        
    }
    private void OnEnable() 
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; 
            dir.Normalize();

        }
        
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score+=10; 

        transform.forward = Vector3.zero;
       
        GameObject explosion = Instantiate(explosionFactory); 
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet")) 
        {
            other.gameObject.SetActive(false); 
            GameObject player = GameObject.Find("Player"); 
            PlayerFire pf = player.GetComponent<PlayerFire>(); 
            pf.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
     
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                SceneManager.LoadScene("Stage05_minigame");
            }else if(other.gameObject.layer == LayerMask.NameToLayer("Player03"))
            {
                SceneManager.LoadScene("Stage03_minigame");
            }
            
        gameObject.SetActive(false);

        EnemyManager.enemyObjectPool.Add(other.gameObject);
    }
}
