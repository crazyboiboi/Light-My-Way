using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;

    public Slider musicSlider;
    public Slider SFXSlider;

    public AudioManager audioManager;


    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSlider");
    }

    public void StartButton()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Level_Select");
    }


    public void OptionsButton()
    {
        Debug.Log("Options");
        OptionsMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void BackButton()
    {
        Debug.Log("Back to main menu");
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void ExitButton()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void SetMusicVolume(float volume)
    {
        audioManager.SetMusicVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioManager.SetSFXVolume(volume);
    }



}
