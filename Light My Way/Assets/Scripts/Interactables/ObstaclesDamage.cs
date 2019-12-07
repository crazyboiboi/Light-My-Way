using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDamage : MonoBehaviour {

    public int damage;
    public bool instantDeath;
    public float countdownTimer;

    bool playerInRange = false;
    float timer;    
    PlayerStats playerStats;
    GameObject player;

    private void Start()
    {
        timer = 0;
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (playerInRange && timer <= 0)
        {
            DamagePlayer();            
        }

        if (playerStats.currentHealth < 0)
        {
            Debug.Log("Player Dead!");
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            if (instantDeath)
            {
                Instakill();
            } else
            {
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        timer = 0;
    }

    void Instakill()
    {
        playerStats.TakeDamage(playerStats.currentHealth);
    }


    void DamagePlayer()
    {
        timer = countdownTimer;
        if (playerStats.currentHealth > 0)
        {
            playerStats.TakeDamage(damage);
        }

    }


}
