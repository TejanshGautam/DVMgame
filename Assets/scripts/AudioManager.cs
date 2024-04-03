using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public Slider musicVolumeSlider; // Reference to the music volume slider in the scene
    public Slider sfxVolumeSlider; // Reference to the SFX volume slider in the scene

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
            musicVolumeSlider.value = musicVolume; // Set the slider value to the loaded volume
        }
        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
            sfxVolumeSlider.value = sfxVolume; // Set the slider value to the loaded volume
        }

        // Set initial volume levels
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);

        // Set listeners for volume sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

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
        // Check if the scene being loaded is the specific scene where you want to change the music
        if (sceneName == "Main")
        {
            // Find the appropriate music clip for the "main" scene
            Sound s = Array.Find(musicSounds, x => x.name == sceneName + "_music");

            if (s == null)
            {
                Debug.Log("Music not found for scene: " + sceneName);
            }
            else
            {
                // Play the music for the "main" scene
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
        else
        {
            // For all other scenes, play a specific background music
            // You can adjust the music clip name or logic based on your specific requirements
            Sound specificMusic = Array.Find(musicSounds, x => x.name == "BGmusic");

            if (specificMusic == null)
            {
                Debug.Log("Specific music not found for scene: " + sceneName);
            }
            else
            {
                // Play the specific background music for all other scenes
                musicSource.clip = specificMusic.clip;
                musicSource.Play();
            }
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
