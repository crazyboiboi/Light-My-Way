using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBehaviour : MonoBehaviour {

    public bool LightMaterial;
    public bool openable;
    public bool locked;
    public bool push;
    public bool stepped;
    public bool isStepped;
    public int requiredLightMaterial;

    public Animator anim;


    public void Open()
    {
        anim.SetBool("Unlocked", true);
    }

    public void SwitchPushed()
    {
        anim.SetBool("Pushed", true);
    }

    public void SwitchStepped()
    {
        anim.SetBool("Stepped", true);
    }


}
