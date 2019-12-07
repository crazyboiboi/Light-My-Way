using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject currentObj = null;
    public InteractableBehaviour currentObjScript;

    PlayerInventory playerInventory;
    bool keyPressed;
    

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }


    private void Update()
    {
        if(currentObj)
        {
            if (currentObjScript.LightMaterial)
            {
                AddLightCollectable();
                Debug.Log("Light material collected.");
                Destroy(currentObj);

            }
            else if (currentObjScript.openable)
            {
                if (currentObjScript.locked)
                {
                    if (CheckForItem())
                    {
                        Debug.Log("Door unlocked");
                        currentObjScript.locked = false;
                        currentObjScript.Open();
                    }
                    else
                    {
                        Debug.Log("Need " + currentObjScript.requiredLightMaterial + " light material");
                    }
                }
                else
                {
                    Debug.Log("Its unlocked. You can pass");
                }
            }
            else if (currentObjScript.push)
            {
                if (currentObjScript.locked && Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("Firewall disabled");
                    currentObjScript.locked = false;
                    currentObjScript.SwitchPushed();
                }
            }
            else if (currentObjScript.stepped)
            {               
                currentObjScript.SwitchStepped();
                currentObjScript.isStepped = true;
            }
        }
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Interactable"))
        {
            currentObj = other.gameObject;
            currentObjScript = currentObj.GetComponent<InteractableBehaviour>();                        
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.gameObject == currentObj)
            {
                currentObj = null;
                currentObjScript = null;
            }
        }

    }


    void AddLightCollectable()
    {
        playerInventory.LightCollectable++;
    }



    private bool CheckForItem()
    {
        var currentAmount = playerInventory.LightCollectable;
        var requiredAmount = currentObjScript.requiredLightMaterial;

        if (currentAmount == requiredAmount)
        {
            return true;
        }
        return false;
    }


}
