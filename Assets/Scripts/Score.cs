using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{

    //Score
    public int scoreAmount;
    public bool win;
    private Timer timerScript;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 5;
        timerScript = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
       scoreText.text = scoreAmount.ToString();

        if (scoreAmount == 0)
        {
            win = true;
            timerScript.timerIsRunning = false;
            DataPersistence.sharedInstance.time = timerScript.timer;
            SceneManager.LoadScene("Win");

        }
    }
}
