using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;

    public Transform dummyModel;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float xOffset = 0f;
    public float yOffset = -1.35f;
    public float zOffset = -0.6f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask assetMask;

    Vector3 velocity;
    bool isGrounded;
    bool onAsset;

    public AudioClip deathSound;
    public float DeathVolume = 0.5f;
    private AudioSource audioSource;

    public float delay;

    private bool Dying = false;

    public DeathScreen deathScreen;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        onAsset = Physics.CheckSphere(groundCheck.position, groundDistance, assetMask);
        
        if ((isGrounded || onAsset) && velocity.y <0)
        {
            velocity.y = -2f;
            animator.SetBool("Jump", false);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!Dying)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
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

        if (Input.GetButtonDown("Jump") && (isGrounded || onAsset)) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jump", true);
        }

        float moveForward = Input.GetAxisRaw("Vertical");
        float strafe = Input.GetAxisRaw("Horizontal");
        
        if (!Dying)
        {
            if (moveForward > 0)
            {
                animator.SetFloat("ForwardSpeed", 1f); 
            }
            else if (moveForward < 0)
            {
                animator.SetFloat("BackwardSpeed", 1f);
            }
            else
            {
                animator.SetFloat("ForwardSpeed", 0f);
                animator.SetFloat("BackwardSpeed", 0f);
            }
            if (strafe < 0)
            {
                animator.SetFloat("LeftSpeed", 1f);
            }
            else if (strafe > 0)
            {
                animator.SetFloat("RightSpeed", 1f);
            }
            else
            {
                animator.SetFloat("LeftSpeed", 0f);
                animator.SetFloat("RightSpeed", 0f);
            }
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (dummyModel != null)
        {
            // Define local space offset values
            Vector3 localOffset = new Vector3(xOffset, yOffset, zOffset);

            // Convert the local offset to world space
            Vector3 adjustedPosition = transform.TransformPoint(localOffset);

            // Apply the adjusted position to the dummy model
            dummyModel.position = adjustedPosition;
        }

    }

    private IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(delay);
    }

    public void Die()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound, DeathVolume);
        }
        else
        {
            Debug.LogWarning("Missing AudioSource or DeathSound on player.");
        }
        Dying = true;
        deathScreen.ShowDeathScreen();
    }
}
