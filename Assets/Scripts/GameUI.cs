using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject blackFade;
    //bools
    public bool dead = false;
    public bool gameOver = false;
    public bool paused = false;
    void Awake()
    {
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        blackFade.SetActive(true);
        optionsMenu.GetComponent<Options>().Load();
    }
    public void PauseMenu()
    {
        if (!dead && !gameOver)
        {
            if (paused)
            {
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                paused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                optionsMenu.SetActive(false);
                Time.timeScale = 0;
                Cursor.visible = true;
                paused = true;
            }
        }
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.visible = true;
    }
    public void ReturnFromLoose(string nextLevel)
    {
        Time.timeScale = 1;
        GameManager.instance.Reset();
        SceneManager.LoadScene(nextLevel);
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
        optionsMenu.SetActive(false);
    }
    public void OpenOptions()
    {
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
