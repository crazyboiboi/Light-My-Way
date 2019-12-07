using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    
    public PlayerStats playerInfoScript;
    public Animator anim;
    public Image blackFader;
    public static bool isGameOver = false;
    public string nextLevel;
    public int levelToUnlock;

    float timer;



    private void Awake()
    {
        isGameOver = false;
        timer = 0f;
    }


    private void Update()
    {
        if(playerInfoScript.isDead)
        {            
            timer += Time.deltaTime;
            isGameOver = true;
            if(timer > 0.5f)
            {
                anim.SetTrigger("Fade");
            }

            if (timer > 2f)
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }



}
