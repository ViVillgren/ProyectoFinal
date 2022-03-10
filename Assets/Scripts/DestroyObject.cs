using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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

    //Win Condition
    private TextMeshProUGUI score;
    private int scoreAmount;
    public bool gameOver;
    public bool win;

    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;

    //Particles & Audio
    public ParticleSystem rewardParticle;
    private AudioSource cameraAudioSource;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Enemy
        hitDamage = 1;
        objectLife = 3;
        currentObjectLife = objectLife;
        pAnimator = GetComponent<Animator>();

        //Win Coindition
        scoreAmount = 5;
        score = GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        score.text = scoreAmount.ToString();

        if (currentObjectLife <=0)
        {
            pAnimator.SetTrigger("triggerDeath");

            if (gameObject.CompareTag("Eggy"))
            {
                scoreAmount -= 1;

                if (scoreAmount == 0)
                {
                    win = true;
                    winText.gameObject.SetActive(true);
                    //playerControllerScript.winAudioSource.PlayOneShot(playerControllerScript.winClip, 1f);
                    cameraAudioSource.Stop();
                }
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
