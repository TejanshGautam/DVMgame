using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // The name of the scene to switch tousing UnityEngine;

        public AudioSource src;
        public AudioClip sfx1;
        public string sceneName;

    // Method to play sound effect and quit the application
    public void SwitchWithSound()
        {
            // Play the quit sound effect
            src.clip = sfx1;
            src.Play();

            // Delay the application quit by the duration of the sound clip
            Invoke("SwitchScene", sfx1.length);
        }

            

            // Method to switch scenes
             public void SwitchScene()
        {
                  SceneManager.LoadScene(sceneName);
        }
}
