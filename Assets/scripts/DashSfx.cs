using UnityEngine;

public class DashSfx : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button3()
    {
        // Check if the AudioManager instance exists
        if (AudioManager.Instance != null)
        {
            // Play the button click sound effect
            AudioManager.Instance.PlaySFX("dash");
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }
}
