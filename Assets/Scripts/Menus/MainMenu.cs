using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< HEAD
=======
    public string levelName = "BaseScene";
>>>>>>> df5eac1441ec466b43e0a87789bb35971412ce49
    public GameObject creditsPanel;
    public GameObject optionsPanel;
    void Awake()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        optionsPanel.GetComponent<Options>().Load();
    }
<<<<<<< HEAD
    public void GoToLevel(string levelName)
=======
    public void GoToLevel()
>>>>>>> df5eac1441ec466b43e0a87789bb35971412ce49
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
