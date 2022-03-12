using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{

    // Aqui se guardaria los datos del Timer. He intentado de todas las maneras para que funcione el PlayerPrefb
    // buscando por todos los lados, pero no ha habido manera.
    public static TimerManager instance;

    public Text timerText;
    public Text textRecord;

    float timer;
    float timerRecord = 0;

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        DisplayTime(DataPersistence.sharedInstance.time);
        timerRecord = PlayerPrefs.GetInt("timerRecord", 0);
        textRecord.text = "Record: " + timerRecord.ToString();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timerRecord > timer)
        {
            PlayerPrefs.SetFloat("timerRecord", timer);
        }
    }

  
}
