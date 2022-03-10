using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameEscene()
    {
        SceneManager.LoadScene("City");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
