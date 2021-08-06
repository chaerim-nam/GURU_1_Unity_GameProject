using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
            if (other.gameObject.name.Contains("Bullet"))
            {
                GameObject player = GameObject.Find("Player");
                PlayerFire pf = player.GetComponent<PlayerFire>();
                pf.bulletObjectPool.Add(other.gameObject);

            }

            if (other.gameObject.name.Contains("Enemy"))
            {
                EnemyManager.enemyObjectPool.Add(other.gameObject);
            }
        }

        
    }
}