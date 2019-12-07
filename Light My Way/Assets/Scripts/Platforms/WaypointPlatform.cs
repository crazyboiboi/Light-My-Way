using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform : MonoBehaviour {

    public Transform[] waypoints;
    public int currentIndex;
    public float moveSpeed;

    GameObject player;    
    PlayerController playerControl;

    private void Start()
    {
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
            currentIndex++;
        }

    }



    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && playerControl.isGrounded)
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }

}
