using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;

    public Transform dummyModel;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float xOffset = -.2f;
    public float yOffset = -1.1f;
    public float zOffset = 0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
            animator.SetBool("Jump", false);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX == 0 && moveZ == 0)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
        //animator.SetFloat("Speed", move.magnitude);

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jump", true);
        } 
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (dummyModel != null)
        {
            // Adjust the Y and Z positions
            float adjustedX = transform.position.x + xOffset;
            float adjustedY = transform.position.y + yOffset;
            float adjustedZ = transform.position.z + zOffset;

            dummyModel.position = new Vector3(adjustedX, adjustedY, adjustedZ);
        }
    }
}
