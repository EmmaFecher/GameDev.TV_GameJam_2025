using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelName = "BaseScene";
    public GameObject creditsPanel;
    public GameObject optionsPanel;
    void Awake()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        optionsPanel.GetComponent<Options>().Load();
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene(levelName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }
}
