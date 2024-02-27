using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController controller;
    public AudioSource footsteps;

    private float MovementSpeed = 7f;
    public float gravity = -500f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private float x;
    private float z;

    private Animator animator;

    void Start() 
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        footsteps = footsteps.GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MovementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (x != 0 || z != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
            footsteps.Stop();
        }

        if (controller.isGrounded == true && animator.GetBool("isWalking") && footsteps.isPlaying == false)
        {
            footsteps.Play();
        }




        
    }


}
