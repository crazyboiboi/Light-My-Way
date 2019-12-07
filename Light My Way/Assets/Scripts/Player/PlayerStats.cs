using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public Image[] healthCountArray;
    public Sprite healthActivate;
    public Sprite healthDeactivate;
    public ParticleSystem ps;
    public bool isDead = false;
    public Image damageImage;

    Vector3 playerPos;
    bool isDamaged;
    Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    float flashSpeed = 5f;



    private void Start()
    {
        currentHealth = maxHealth;
        isDamaged = false;
    }

    private void Update()
    {
        // TO SET UP NUMBER OF ORB

        //    //if (i<maxHealth)
        //    //{
        //    //    healthCountArray[i].enabled = true;
        //    //} else
        //    //{
        //    //    healthCountArray[i].enabled = false;
        //    //}
        //}

        playerPos = transform.position;

        if (isDamaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;
    }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        isDamaged = true;
        Debug.Log("Damage took. HP: " + currentHealth);

        for (int i = 0; i < healthCountArray.Length; i++)
        {
            healthCountArray[i].enabled = true;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            if (i < currentHealth)
            {
                healthCountArray[i].sprite = healthActivate;
            }
            else
            {
                healthCountArray[i].sprite = healthDeactivate;
            }
        }

        if (currentHealth == 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        ps.transform.position = playerPos;
        ps.Play();
        gameObject.SetActive(false);
        isDead = true;        
    }
}

