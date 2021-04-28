using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    
    float startTime;
    float timeDelay = 0.1f;
    float offset = 0.1f;
    
    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        if (Time.time >= startTime + timeDelay)
        {
            offset = offset * -1;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + offset, this.transform.position.z);
            startTime = Time.time;
        }

    }

   
}

