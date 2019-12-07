using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage;

    [SerializeField]
    float timeBetweenAttack = 0.5f;

    PlayerStats playerStats;
    GameObject player;
    bool playerInRange = false;    
    float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
    }



    private void Update()
    {
        timer += Time.deltaTime;


        if (playerInRange && timer > timeBetweenAttack)
        {
            Attack();
        }

        if (playerStats.currentHealth < 0)
        {
            Debug.Log("Player Dead!");
        }

    }




    void Attack()
    {
        timer = 0;

        if (playerStats.currentHealth > 0)
        {
            playerStats.TakeDamage(damage);
        }
    }




}
