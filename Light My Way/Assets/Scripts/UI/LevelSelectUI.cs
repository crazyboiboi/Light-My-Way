using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelectUI : MonoBehaviour {

    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }
    }


    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Level_Select(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("levelReached");
    }




}
