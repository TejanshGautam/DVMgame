using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class SendData : MonoBehaviour
{
    public float audioLevel;
    public Slider sliderVal; 

    public float sfxLevel;
    public Slider sfx;

    void Update()
    {
        audioLevel=sliderVal.value;
        PlayerPrefs.SetFloat("AudioLevel", audioLevel);
        PlayerPrefs.Save();

        sfxLevel=sfx.value;
        PlayerPrefs.SetFloat("sfxLevel", sfxLevel);
        PlayerPrefs.Save();
    }
}
