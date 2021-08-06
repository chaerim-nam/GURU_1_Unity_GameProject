using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    [HideInInspector]
    public List<GameObject> bulletObjectPool; 

    void Start()
    { 
        bulletObjectPool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject bullet = Instantiate(bulletFactory); 
            bulletObjectPool.Add(bullet);
            
            bullet.SetActive(false); 
        }
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0]; 
                bulletObjectPool.RemoveAt(0);
                bullet.SetActive(true); 
                bullet.transform.position = firePosition.transform.position; 
            }
        } 

    } 
}
