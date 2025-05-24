using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Image dimmer;
    public Slider dimSlider;
    public Slider audSlider;
    public void UpdateDimmer()
    {
        dimmer.color = new Color(0, 0, 0, dimSlider.value);
        if (!PlayerPrefs.HasKey("Dimmer"))
        {
            PlayerPrefs.SetFloat("Dimmer", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("Dimmer", dimSlider.value);
        }
        
    }
    public void UpdateVolume()
    {
        AudioListener.volume = audSlider.value;
        if (!PlayerPrefs.HasKey("Audio"))
        {
            PlayerPrefs.SetFloat("Audio", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("Audio", audSlider.value);
        }
    }
    public void Load()
    {
        if (!PlayerPrefs.HasKey("Audio"))
        {
            PlayerPrefs.SetFloat("Audio", 1);
        }
        if (!PlayerPrefs.HasKey("Dimmer"))
        {
            PlayerPrefs.SetFloat("Dimmer", 0);
        }
        dimSlider.value = PlayerPrefs.GetFloat("Dimmer");
        audSlider.value = PlayerPrefs.GetFloat("Audio");
    }
}
