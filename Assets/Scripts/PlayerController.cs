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

    //private Vector3 velocity;
    //private bool isGrounded;

    public float mouseSensitivity = 100f;
    public float rotationSmoothSpeed = 10f;

    private float yaw;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (controller == null)
        {
            Debug.LogError("PlayerController requires a CharacterController component", this);
        }

        if (animator == null)
        {
            Debug.LogError("PlayerController requires an Animator component", this);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void FixedUpdateNetwork()
    {
        if (controller == null || animator == null)
        {
            return;
        }

        if (HasStateAuthority)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Runner.DeltaTime;
            yaw += mouseX;

            Quaternion targetRotation = Quaternion.Euler(0f, yaw, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Runner.DeltaTime);

            /*isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                animator.SetBool("IsJumping", false);
            }*/

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 inputDirection = new Vector3(x, 0, z);
            float inputMagnitude = inputDirection.magnitude;

            if (inputMagnitude > 0.01f)
            {
                inputDirection = inputDirection.normalized;
                Vector3 worldDir = transform.TransformDirection(inputDirection);
                controller.Move(worldDir * speed * Runner.DeltaTime);
            }

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
