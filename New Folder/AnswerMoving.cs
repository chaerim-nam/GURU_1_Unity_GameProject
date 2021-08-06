using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += new Vector3(Random.Range(0, 1400), Random.Range(0, 900), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
