using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    // Method to play sound effect and quit the application
    public void QuitWithSound()
    {
        // Play the quit sound effect
        src.clip = sfx1;
        src.Play();

        // Delay the application quit by the duration of the sound clip
        Invoke("Quit", sfx1.length);
    }

    // Method to quit the application
    private void Quit()
    {
        // Quit the application
        Application.Quit();
    }
}
