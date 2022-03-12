using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //La IA del Enemigo, para que pase de distintos estados hasta atacar al player
    public NavMeshAgent agent;
    public Transform player;
    private Animator pAnimator;
    public LayerMask whatIsGround, whatIsPlayer;

    //Audio
    public AudioSource playerAudioSource;
    public AudioClip attackClip;
    public AudioClip detectClip;



    //Patroling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Collider
    public GameObject colliderAttack;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        pAnimator = GetComponent<Animator>();
    }

    void Start()
    {

        playerAudioSource = GetComponent<AudioSource>();

    }

        void Update()
    {
        //Check for sight and attack
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            //pAnimator.SetBool("isWalk", false);
        }
        else
        {
            //pAnimator.SetBool("isWalk", true);
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {
        //Make sure enemy doest move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            Attack();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {

        alreadyAttacked = false;

    }

    public void Attack()
    {
        pAnimator.SetTrigger("triggerAttack");
        playerAudioSource.PlayOneShot(attackClip, 0.5f);

    }

    public void AttackStart()
    {
        colliderAttack.SetActive(true);
    }

    public void AttackEnd()
    {
        colliderAttack.SetActive(false);
    }
}
