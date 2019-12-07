using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform_Wait : MonoBehaviour {

    public Transform[] waypoints;
    public int currentIndex;
    public float moveSpeed;
    public float countdownTime;

    GameObject player;
    float waitTime;
    PlayerController playerControl;



    private void Start()
    {
        waitTime = countdownTime;
        currentIndex = 0;
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (currentIndex > waypoints.Length - 1)
        {
            currentIndex = 0;
        }

        Move();

        if (Vector2.Distance(transform.position, waypoints[currentIndex].position) < 0.2f)
        {
            if(waitTime < 0)
            {
                currentIndex++;
                waitTime = countdownTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }



    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && playerControl.isGrounded)
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }





}
