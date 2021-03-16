using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timeText;
    float currentTime = 0;
    bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        GameStarts();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime();
        DisplayTime(currentTime);
    }

    private void DisplayTime(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float CurrentTime()
    {
        if (timerIsRunning)
        {
            currentTime += Time.deltaTime;
        }

        return currentTime;
    }

    public bool GameStarts()
    {
        timerIsRunning = true;
        return timerIsRunning;
    }
}
