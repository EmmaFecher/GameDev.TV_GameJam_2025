using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public string SceneToGoTo;
    public Image blackFade;
    void Start()
    {
        StartCoroutine(UnFade());
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
            if (pm.canControl)
            {
                if (pm.fireInput)
                {
                    Debug.Log("Move");
                    GoToScene();
                    pm.fireInput = false;
                }
            }
        }
    }
    private void GoToScene()
    {
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().canControl = false;


        StartCoroutine(Fade());

        SceneManager.LoadScene(SceneToGoTo);
    }
    IEnumerator Fade()
    {
        var tempColor = blackFade.color;
        tempColor.a += .01f;
        blackFade.color = tempColor;
        if (blackFade.color.a < 1)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(.001f);
            StartCoroutine(Fade());
        }
    }
    IEnumerator UnFade()
    {
        var tempColor = blackFade.color;
        tempColor.a -= .01f;
        blackFade.color = tempColor;
        if (blackFade.color.a < 0)
        {
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().canControl = true;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(.001f);
            StartCoroutine(UnFade());
        }
    }
}
