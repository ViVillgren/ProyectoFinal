using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    // para que los datos no se destruyan entre escenas
    public static DataPersistence sharedInstance;
    public float time;


    private void Awake()
    {
     if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this);
        }
     else
        {
            Destroy(gameObject);
        }
    }

}
