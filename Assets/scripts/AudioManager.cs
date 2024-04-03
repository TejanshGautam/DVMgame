using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

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
        // Load volume levels
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
        }
        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
        }

        // Set initial volume levels
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;

        // Assuming the initial scene has been loaded
        Scene currentScene = SceneManager.GetActiveScene();
        UpdateBackgroundMusic(currentScene.name);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateBackgroundMusic(scene.name);
    }

    private void UpdateBackgroundMusic(string sceneName)
    {
        // Find the appropriate music clip for the scene
        Sound s = Array.Find(musicSounds, x => x.name == sceneName + "_music");

        if (s == null)
        {
            Debug.Log("Music not found for scene: " + sceneName);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = musicVolume;

        // Save volume level
        PlayerPrefs.SetFloat(MusicVolumeKey, musicVolume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;

        // Save volume level
        PlayerPrefs.SetFloat(SFXVolumeKey, sfxVolume);
        PlayerPrefs.Save();
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
