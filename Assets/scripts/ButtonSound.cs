using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    // Method to play sound effect
    public void PlaySound()
    {
        // Play the sound effect
        src.clip = sfx1;
        src.Play();
    }
}
