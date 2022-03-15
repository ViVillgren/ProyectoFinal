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

    public Text timerText;
    public Text textRecord;

    float timer;
    float timerRecord;

    
    void Start()
    {
        timer = DataPersistence.sharedInstance.time;
        timerRecord = PlayerPrefs.GetFloat("TimeRecord");

        if (timerRecord > timer)
        {
            PlayerPrefs.SetFloat("timerRecord", timer);
            timerRecord = PlayerPrefs.GetFloat("TimeRecord");
        }
        timerText.text = DisplayTime(timer);

        textRecord.text = $"Record: {DisplayTime(timerRecord)}"; 
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
