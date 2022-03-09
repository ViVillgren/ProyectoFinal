using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    //este script con la ayuda de un gameobject hara que el player aparezca al lado del portal de cada escena
    // y que no aparezca directamente arriba en la otra escena al coger el portal de arriba de la primera

    public string lastExitName;


    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            newThirdPersonController.instance.transform.position = transform.position;
            newThirdPersonController.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
