using UnityEngine;

public class AttackSfx : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button2()
    {
        // Check if the AudioManager instance exists
        if (AudioManager.Instance != null)
        {
            // Play the button click sound effect
            AudioManager.Instance.PlaySFX("attack");
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }
}

