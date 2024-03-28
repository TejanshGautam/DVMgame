using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    private Slider volumeSlider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        FindVolumeSlider();
        LoadVolume();
    }

    void FindVolumeSlider()
    {
        volumeSlider = GameObject.FindObjectOfType<Slider>();
        if (volumeSlider == null)
        {
            Debug.LogWarning("Volume slider not found in the scene.");
        }
    }

    public void ChangeVolume()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = volumeSlider.value;
            SaveVolume();
        }
    }

    public void SaveVolume()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
            PlayerPrefs.Save();
        }
    }

    public void LoadVolume()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.6f);
        }
    }
}
