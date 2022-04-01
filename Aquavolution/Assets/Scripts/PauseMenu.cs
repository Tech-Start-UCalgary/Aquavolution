using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Text ScoreText;
    public GameObject PauseMenuScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused){
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ScoreText.text = "Score: " + PlayerStats.FoodCount.ToString();
    }

    public void Exit()
    {
        SceneManager.LoadScene("SplashScene");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
