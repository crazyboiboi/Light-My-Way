using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchFallPlatform : MonoBehaviour
{

    bool playerOn;
    bool platformFall;
    float fallSpeed = 2f;
    float timer;
    Vector3 originalPosition;


    private void Start()
    {
        originalPosition = transform.position;
        timer = 0;
    }


    private void Update()
    {
        if (platformFall)
        {
            Move();
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                transform.position = originalPosition;
                timer = 0;
                platformFall = false;
            }
        }
    }


    void Move()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerOn = true;
            platformFall = true;
            if(playerOn)
            {
                other.transform.parent = transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerOn = false;
        other.transform.parent = null;
    }
}
