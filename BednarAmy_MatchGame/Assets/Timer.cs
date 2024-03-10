using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public Text timerText;
    //WHY won't it accept the line below? I get a red flag.
    public TextMeshProUGUI timerText;
    public float totalTime = 60f; // Total time in seconds

    private float timeRemaining;
    public GameObject looseCanvas;

    void Start()
    {

        timeRemaining = totalTime;
        timerText.text = timeRemaining.ToString();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrease time remaining by the time since last frame
            UpdateTimerDisplay();
        }
        else
        {
            // Timer has reached zero, do something (e.g., end game)
            Debug.Log("Time's up!");
            timeRemaining = 0;
            looseGameFunc();
            UpdateTimerDisplay();
        }
    }

    public void looseGameFunc()
    {
        looseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    void UpdateTimerDisplay()
    {
        // Convert time remaining to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the timer display text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
