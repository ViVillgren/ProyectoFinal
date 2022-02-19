using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayerAttack : MonoBehaviour
{
    private Animator pAnimator;

    //Collider
    public GameObject colliderAttack;

    private bool canAttack;


    // Start is called before the first frame update
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        pAnimator.SetTrigger("triggerAttack");

    }

    public void AttackStart()
    {
        colliderAttack.SetActive(true);
        canAttack = false;
    }

    public void AttackEnd()
    {
        colliderAttack.SetActive(false);
        canAttack = true;
    }
}
