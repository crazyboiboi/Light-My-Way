using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour {

    public GameObject lightHolder;
    public GameOverManager gameOverManager;

    InteractableBehaviour interactableBehaviour;

    private void Start()
    {
        interactableBehaviour = lightHolder.GetComponent<InteractableBehaviour>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(!interactableBehaviour.locked)
            {
                gameOverManager.WinLevel();
                Debug.Log("Changing level");
            } else
            {
                Debug.Log("You need to unlock it first");
            }
        }
    }



}
