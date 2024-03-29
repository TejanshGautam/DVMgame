using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] float remainingTime;
    [SerializeField] Color redColor; // Color for the text when the remaining time is 10 seconds or less

    private bool isRed; // Flag to track if the text color is red
    private bool isGlowingUp; // Flag to track if the glow effect is increasing
    private bool isTimerFinished; // Flag to track if the timer has finished (reached 0:00)

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0 && !isTimerFinished)
        {
            remainingTime -= Time.deltaTime;

            // Check if remaining time is 10 seconds or less and the text color is not red
            if (remainingTime <= 10 && !isRed)
            {
                timertext.color = redColor; // Change text color to red
                isRed = true; // Set the flag to true to indicate text color is red
            }

            // Perform glow effect when the remaining time is between 10 and 0 seconds
            if (remainingTime <= 10)
            {
                float glowIntensity = Mathf.PingPong(Time.time * 3, 1); // Adjust the frequency and intensity of the glow
                timertext.color = redColor * glowIntensity;
            }
        }
        else
        {
            remainingTime = 0;
            isTimerFinished = true; // Set the timer finished flag to true
            timertext.color = redColor; // Keep the text color red
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
