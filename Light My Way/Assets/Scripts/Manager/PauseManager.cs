using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public PlayerStats playerStats;

    public Slider musicSlider;
    public Slider SFXSlider;


    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSlider");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameOverManager.isGameOver)
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }


    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
        Debug.Log("Back to main menu!");
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager._instance.SetMusicVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager._instance.SetSFXVolume(volume);
    }



}
