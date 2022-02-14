using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newThirdPersonController : MonoBehaviour
{

    //component
    private CharacterController charController;
    private Animator pAnimator;


    //
    private Transform meshPlayer;
    private float gravity;
    private bool isGrounded;
    private float groundCheckDistance;
    private LayerMask groundMask;

    //move
    private float inputX;
    private float inputZ;
    private Vector3 vMovement;
    private float moveSpeed;
    private Vector3 velocity;
    private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
        gravity = -9.8f;
        jumpHeight = 1.5f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        charController = tempPlayer.GetComponent<CharacterController>();
        pAnimator = tempPlayer.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y >0)
        {
            velocity.y = -2f;
        }


        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if(isGrounded)
        {
            if (inputX == 0 && inputZ == 0)
            {
                pAnimator.SetBool("isWalk", false);
                pAnimator.SetBool("isRun", false);
            }
            else if (inputX < 0.5f && inputX > -0.5f && inputZ < 0.5f && inputZ > -0.5)
            {
                pAnimator.SetBool("isWalk", true);
            }

            else
            {
                pAnimator.SetBool("isRun", true);
            }

            if(Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Debug.Log("Jump");
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            pAnimator.SetTrigger("triggerAttack");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            pAnimator.SetTrigger("triggerAttack");
        }

        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);

    }


    private void FixedUpdate()
    {
        /*
        // Gravity
        if (charController.isGrounded)
        {
            vMovement.y = 0f;
        }
        else
        {
            vMovement.y -= gravity + Time.deltaTime;
        }
        */

        //movement
        vMovement = new Vector3(inputX * moveSpeed, vMovement.y, inputZ * moveSpeed);
        charController.Move(vMovement);

        // mesh rotate
        if (inputX != 0 || inputZ !=0)
        {
            Vector3 lookDir = new Vector3(vMovement.x, 0, vMovement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
      
    }
}
