using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour {

    public Animator anim;
    public GameObject[] switches;

    GameObject[] poweredObjects;

    private void Start()
    {
        poweredObjects = GameObject.FindGameObjectsWithTag("PowerNeeded");
        for (int i = 0; i < poweredObjects.Length; i++)
        {
            poweredObjects[i].GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void Update()
    {
        if(areAllSwitchesStepped())
        {
            Debug.Log("Generator powered");
            anim.SetBool("Stepped", true);
            
            for (int i = 0; i < poweredObjects.Length; i++)
            {
                poweredObjects[i].GetComponent<WaypointPlatform_Wait>().enabled = true;
                poweredObjects[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
            
        }
    }

    private bool areAllSwitchesStepped()
    {
        for (int i = 0; i<switches.Length; i++)
        {
            if (switches[i].GetComponent<InteractableBehaviour>().isStepped == false) 
            {
                return false;
            } 
        }
        return true;
    }


}
