using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class receiveData : MonoBehaviour
{
    public float audioLevel;
    public Slider sliderVal;

    public float sfxLevel;
    public Slider sfx;

    void Start()
    {
        if (PlayerPrefs.HasKey("AudioLevel"))
        {
            audioLevel= PlayerPrefs.GetFloat("AudioLevel");
            Debug.Log(audioLevel);
            sliderVal.value=audioLevel;
        }
        else
        {
            Debug.Log("No data received.");
        }

        if (PlayerPrefs.HasKey("sfxLevel"))
        {
            sfxLevel= PlayerPrefs.GetFloat("sfxLevel");
            sfx.value=sfxLevel;
        }
        else
        {
            Debug.Log("No data received.");
        }
    }

    void update(){
        audioLevel=sliderVal.value;
        PlayerPrefs.SetFloat("AudioLevel", audioLevel);
        PlayerPrefs.Save();

        sfxLevel=sfx.value;
        PlayerPrefs.SetFloat("sfxLevel", sfxLevel);
        PlayerPrefs.Save();
    }

}
