using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float levelTime;
    public GameObject gameOverPanel;
    public AudioSource audioPopUp;

    private bool started = false;
    public bool hasIncreasedTime = false;

    void Start()
    {
        StartTimer();

    }

    void Update()
    {
        if (started)
        {
            levelTime -= Time.deltaTime;
            UpdateTime();

            if (levelTime <= 0)
            {
                GameOver();
            }
        }
    }

    public void StartTimer()
    {
        started = true;
    }

    void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(levelTime / 60);
        int seconds = Mathf.FloorToInt(levelTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        levelTime = 0;
        UpdateTime();
        started = false;
        gameOverPanel.SetActive(true);
        audioPopUp.Play();
        Time.timeScale = 0f;
    }
}
