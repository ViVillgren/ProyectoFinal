using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    // Aqui se encuentra la funcion de que cuando mates a todos los enemigos que te piden ganas la partida
    //ademas de mostrase por UI el numero que quedan de enemigos
    //Score
    public int scoreAmount;
    public bool win;
    private Timer timerScript;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreAmount = 5;
        timerScript = GetComponent<Timer>();
    }

    void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
       scoreText.text = $"X {scoreAmount.ToString()}";
   

        if (scoreAmount == 0)
        {
            win = true;
            timerScript.timerIsRunning = false;
            DataPersistence.sharedInstance.time = timerScript.timer;
            SceneManager.LoadScene("Win");

        }
    }
}
