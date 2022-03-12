using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromPlayer : MonoBehaviour
{
    // Con este script el enemigo se alejaria del player cuando este se acercase
    private NavMeshAgent agent;
    public GameObject player;
    public float EnemyDistanceRun;

    private Animator pAnimator;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //segun la distancia que pongas empezara a correr antes o despues
        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            
            var newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);

            Move(true);
        }
        else
        {
            Move(false);
        }


    }

    private void Move(bool walk)
    {

        //Idle
        if (walk)
        {
            pAnimator.SetBool("isWalk", true);
        }
        //Walk
        else
        {
            pAnimator.SetBool("isWalk", false);
        }
    }
}
