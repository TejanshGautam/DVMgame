using UnityEngine;



public class BlockSfx : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button4()
    {
        // Check if the AudioManager instance exists
        if (AudioManager.Instance != null)
        {
            // Play the button click sound effect
            AudioManager.Instance.PlaySFX("block");
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }
}
