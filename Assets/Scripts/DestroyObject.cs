using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] private float hitDamage;
    [SerializeField] private float objectLife;

    private float currentObjectLife;

    // Start is called before the first frame update
    void Start()
    {
        hitDamage = 1;
        objectLife = 3;
        currentObjectLife = objectLife;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentObjectLife <=0)
        {
            Destroy(gameObject,1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerAttack"))
        {
            currentObjectLife -= hitDamage;
        }
    }
}
