using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DestroyObject : MonoBehaviour
{

    //Funcion para matar a los enemigos, segun las armas que uses pueden afectar a uno o a otro, pero no a los 2
    private Score score;

    [SerializeField] private float hitDamage;
    [SerializeField] private float objectLife;
    [SerializeField] private LayerMask weaponLayer;
    private Animator pAnimator;

    private float currentObjectLife;

    public bool dropItem;
    public GameObject[] itemsToDrop;

    private float maxDistance = 1;

    //Win Condition
    public bool win;

    //UI
    public TextMeshProUGUI scoreText;


    //Particles & Audio
    //public ParticleSystem rewardParticle;
    public AudioClip missClip;
    public AudioClip hitClip;
    public AudioClip deathClip;
    public AudioSource playerAudioSource;

    public ParticleSystem missParticle;
    public ParticleSystem hitParticle;
    public ParticleSystem explosionParticle;

    void Start()
    {
        //Enemy
        hitDamage = 1;
        objectLife = 3;
        currentObjectLife = objectLife;
        pAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        //Win Coindition
        //scoreAmount = 5;
        scoreText = GetComponent<TextMeshProUGUI>();

        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (currentObjectLife <=0)
        {
            
            Destroy(gameObject,0.5f);
            


        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //aqui al activar el colider de la animacion de atacar del player segun la etiqueta que tiene el enemigo le haria daño o no

        if(other.gameObject.CompareTag("PlayerAttack"))
        {
            pAnimator.SetTrigger("triggerDamage");
            

            if ((weaponLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                currentObjectLife -= hitDamage;
                playerAudioSource.PlayOneShot(hitClip, 0.5f);
                Instantiate(hitParticle, transform.position, hitParticle.transform.rotation);
            }
            else
            {
                playerAudioSource.PlayOneShot(missClip, 1f);
                Instantiate(missParticle, transform.position, missParticle.transform.rotation);
            }

        }
    }

    private void OnDestroy()
    {
        pAnimator.SetTrigger("triggerDeath");
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1f);

        //Si matamos al enemigo catalogado como Eggy se descontara un punto de la score, llegando a 0 se gana la partida
        if (gameObject.CompareTag("Eggy"))
        {
           score.scoreAmount = score.scoreAmount -= 1;

        }

        if (dropItem)
        {

            //Al matar al enemigo soltaria un objeto
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
