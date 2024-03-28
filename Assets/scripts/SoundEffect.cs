using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    // Start is called before the first frame update
    public void button1()
    {
        src.clip = sfx1;
        src.Play();
    }
}
