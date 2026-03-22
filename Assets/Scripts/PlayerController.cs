using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerController : NetworkBehaviour
{
    public float speed = 20f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Animator animator;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            /*isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                animator.SetBool("IsJumping", false);
            }*/

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //Vector3 move = transform.right * x + transform.forward * z;
            Vector3 direction = new Vector3(x, 0, z);
            if (direction.magnitude >0.1f)
            {
                controller.Move(direction * speed * Runner.DeltaTime);
                transform.rotation = Quaternion.LookRotation(direction);
            }

            //controller.Move(move * speed * Time.deltaTime);
            
            float moveSpeed = new Vector2(x, z).magnitude;
            animator.SetFloat("Speed", moveSpeed);
            /*
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animator.SetBool("IsJumping", true);
            }
            
            velocity.y += gravity * Runner.DeltaTime;
            controller.Move(velocity * Runner.DeltaTime);*/
        }
    }
}
