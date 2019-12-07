using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWP : MonoBehaviour {

    public float speed;
    public Transform[] waypoints;

    int currentIndex;
    bool movingRight = true;

    private void Start()
    {
        currentIndex = 0;
    }


    private void Update()
    {
        if(currentIndex > waypoints.Length - 1)
        {
            currentIndex = 0;
        }

        Move();

    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, waypoints[currentIndex].position) < 0.2f)
        {
            Flip();
            currentIndex++;
        }
    }


    void Flip()
    {
        movingRight = !movingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }



}
