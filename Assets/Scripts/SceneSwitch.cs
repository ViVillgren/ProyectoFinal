using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //Carga la escena nombrada al colicionar con el gameobject que lleva el script

    public string sceneToLoad;
    public string exitName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("LastExitName", exitName);
        SceneManager.LoadScene(sceneToLoad);

        if(other.gameObject.CompareTag("Player"))
            {
            PlayerPrefs.SetString("LastExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
        }
            
    }

}
