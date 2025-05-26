using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject blackFade;
    public GameObject tutorialPanel;
    public bool tutorialScene = false;
    public TextMeshProUGUI current;
    public TextMeshProUGUI max;
    public TextMeshProUGUI score;
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
        UpdateBackpack();
    }
    public void PauseMenu()
    {
        if (!dead && !gameOver)
        {
            if (paused)
            {
                //unpausing
                if (tutorialScene)
                {
                    if (GameManager.instance.firstTime)
                    {
                        //turn back on tutorial panel
                        tutorialPanel.SetActive(true);
                    }
                }
                
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                paused = false;
            }
            else
            {
                //pausing
                pauseMenu.SetActive(true);
                if (tutorialScene)
                {
                    tutorialPanel.SetActive(false);
                }
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
        if (tutorialScene)
            tutorialPanel.SetActive(false);
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
        if (tutorialScene)
        {
            if (GameManager.instance.firstTime)
            {
                //turn back on tutorial panel
                tutorialPanel.SetActive(true);
            }
        }
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

    public void UpdateBackpack()
    {
        current.text = GameManager.instance.currentMouseInventory.ToString();
        max.text = GameManager.instance.maxMouseInventory.ToString();
        score.text = GameManager.instance.score.ToString();
    }
}
