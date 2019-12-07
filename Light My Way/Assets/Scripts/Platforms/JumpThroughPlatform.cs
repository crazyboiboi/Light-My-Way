using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughPlatform : MonoBehaviour {

    PlatformEffector2D effector;
    float waitTime;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.5f;
        }

        if(Input.GetKey(KeyCode.S))
        {
            if (waitTime < 0)
            {
                effector.rotationalOffset = 180;
                waitTime = 0.5f;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }


        if(Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }


    }


}
