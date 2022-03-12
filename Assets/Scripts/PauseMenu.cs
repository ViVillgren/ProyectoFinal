using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Pausa el juego al pulsar el start del mando o el escape del teclado
    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }

}
