using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    //Script del contador, cuando empiece el juego epieza a contar y para una vez ganes o pierdas la partida
    // si ganas se mostrara el tiempo final en la escena de Win
    public float timer;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

    }
    void Update()
    {
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
        }

    
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
