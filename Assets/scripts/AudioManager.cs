using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Change Instance to instance

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource; // Rename MusicSource to musicSource

    private void Awake()
    {
        if (Instance == null)
        {   
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BGmusic"); // Change playmusic to PlayMusic
    }

    public void PlayMusic(string name) // Change playmusic to PlayMusic
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
