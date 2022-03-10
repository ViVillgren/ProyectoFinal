using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromPlayer : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject player;
    public float EnemyDistanceRun;

    private Animator pAnimator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

       //Run from Player
       if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            var newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);

            pAnimator.SetBool("isWalk", true);
        }


    }
}
