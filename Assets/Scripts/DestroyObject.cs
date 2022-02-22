using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] private float hitDamage;
    [SerializeField] private float objectLife;
    [SerializeField] private LayerMask weaponLayer;
    private Animator pAnimator;

    private float currentObjectLife;

    // Start is called before the first frame update
    void Start()
    {
        hitDamage = 1;
        objectLife = 3;
        currentObjectLife = objectLife;
        pAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentObjectLife <=0)
        {
            pAnimator.SetTrigger("triggerDeath");
            Destroy(gameObject,2);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerAttack"))
        {
            pAnimator.SetTrigger("triggerDamage");
            

            if ((weaponLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                currentObjectLife -= hitDamage;
                //sonido correcto
            }
            else
            {
                //Sonido incorrecto
            }

        }
    }
}
