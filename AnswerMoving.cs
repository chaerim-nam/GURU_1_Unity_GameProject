using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += new Vector3(0, Random.Range(-10, 10) * 10.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
