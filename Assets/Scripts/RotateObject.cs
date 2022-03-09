using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateAspa = 20f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate (Vector3.up *Time.deltaTime * rotateAspa);
    }

}
