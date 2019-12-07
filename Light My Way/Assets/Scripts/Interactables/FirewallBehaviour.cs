using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallBehaviour : MonoBehaviour {

    public GameObject Switch;
    public Animator anim;
    InteractableBehaviour interactableBehaviour;
    float timer;

    private void Start()
    {
        interactableBehaviour = Switch.GetComponent<InteractableBehaviour>();
        timer = 0;
    }

    private void Update()
    {
        if (!interactableBehaviour.locked)
        {
            anim.SetBool("Disabled", true);
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                gameObject.SetActive(false);
            }
        }
    }


}
