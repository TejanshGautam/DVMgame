using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button1()
    {
        // Check if the AudioManager instance exists
        if (AudioManager.Instance != null)
        {
            // Play the button click sound effect
            AudioManager.Instance.PlaySFX("buttonclick");
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }
}
