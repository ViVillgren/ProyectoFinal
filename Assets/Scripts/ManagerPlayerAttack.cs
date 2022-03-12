using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayerAttack : MonoBehaviour
{

    //Con esto hacemos que el que la funcion de atacar del player funcione, no solo la animacion si no que tambien
    // que haga daño siempre que haga la animacion de atacar y que el collider no este siempre activo añadiendo unas etiquetas en la animacion
    // y un objeto que haga de collider
    private Animator pAnimator;

    //Collider
    public GameObject colliderAttack;

    private bool canAttack;


    void Start()
    {
        pAnimator = GetComponent<Animator>();
        canAttack = true;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire2") && canAttack)
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
