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

    public bool dropItem;
    public GameObject[] itemsToDrop;

    private float maxDistance = 1;

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
            if (gameObject.CompareTag("Eggy"))
            {
                GameManager.sharedInstance.KillEnemy();
            }
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

    private void OnDestroy()
    {
        if (dropItem)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(itemsToDrop[0], RandomPos(), Quaternion.identity);
            }
        }
    }

    private Vector3 RandomPos()
    {
        float x = Random.Range(transform.position.x - maxDistance, transform.position.x + maxDistance);
        float z = Random.Range(transform.position.z - maxDistance, transform.position.z + maxDistance);

        return new Vector3(x, 0.5f, z);
    }
}
