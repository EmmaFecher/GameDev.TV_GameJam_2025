using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject pauseMenu;
    public GameObject blackFade;
    //bools
    public bool dead = false;
    public bool gameOver = false;
    public bool paused = false;
    void Awake()
    {
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        blackFade.SetActive(true);
    }
    public void PauseMenu()
    {
        if (!dead && !gameOver)
        {
            if (paused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                paused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                paused = true;
            }
        }
    }
    public void GameOver(bool win)
    {
        gameOver = true;
        GameOverMenu.SetActive(true);
        Cursor.visible = true;
    }
    public void GoToLevel(string nextLevel)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevel);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
}
