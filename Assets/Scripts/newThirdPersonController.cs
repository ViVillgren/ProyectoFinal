using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newThirdPersonController : MonoBehaviour
{

    //component
    private CharacterController charController;
    private Animator pAnimator;
    public Transform camara;


    //
    private Transform meshPlayer;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] Transform checkGround;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;

    //move
    private float inputX;
    private float inputZ;
    private Vector3 vMovement;
    private float moveSpeed;
    private Vector3 velocity;
    [SerializeField] private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
       
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        charController = tempPlayer.GetComponent<CharacterController>();
        pAnimator = tempPlayer.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y > 0)
        {
            velocity.y = -2f;
        }


        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");


        if (isGrounded)
        {
            //Idle
            if (inputX == 0 && inputZ == 0)
            {
                pAnimator.SetBool("isWalk", false);
                pAnimator.SetBool("isRun", false);
            }
            //Walk
            else if (inputX < 0.5f && inputX > -0.5f && inputZ < 0.5f && inputZ > -0.5)
            {
                pAnimator.SetBool("isWalk", true);
            }
            //Run
            else
            {
                pAnimator.SetBool("isRun", true);
            }
            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Debug.Log("Jump");
            }

            
        }

        //movement
        vMovement = new Vector3(inputX * moveSpeed, vMovement.y, inputZ * moveSpeed);
        vMovement = Quaternion.AngleAxis(camara.rotation.eulerAngles.y, Vector3.up) * vMovement;
        
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            pAnimator.SetTrigger("triggerAttack");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            pAnimator.SetTrigger("triggerAttack");
        }
        */

        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        charController.Move(vMovement);

        // mesh rotate
        if (inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(vMovement.x, 0, vMovement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }

    }
}