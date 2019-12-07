using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public Slider lightSlider;
    public int LightCollectable;

    InteractableBehaviour interactableBehaviour;
    GameObject lightHolder;


    private void Start()
    {
        LightCollectable = 0;
        lightHolder = GameObject.Find("Light holder");
        interactableBehaviour = lightHolder.GetComponent<InteractableBehaviour>();
        lightSlider.maxValue = interactableBehaviour.requiredLightMaterial;
        lightSlider.value = 0;
    }

    private void Update()
    {
        lightSlider.value = LightCollectable;
    }

}
