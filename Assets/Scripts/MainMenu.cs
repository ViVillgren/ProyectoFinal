using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Cuando de escena o sale del juego segun al boton que apretes
    public void GameEscene()
    {
        SceneManager.LoadScene("City");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
