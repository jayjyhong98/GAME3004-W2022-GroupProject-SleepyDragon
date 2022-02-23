//*********************************************************************************************************
// Author: Pauleen Lam, Jeongyeon Jane Hong
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Player.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField, Header("Player Movement")]
    private float movementSpeed = 8;
    [SerializeField]
    private float jumpForce = 7;
    //[SerializeField]
    //private float cameraRotationSensitivity = 30;
    //private float playerRotationSpeed = 10;

    // Player Jump
    [SerializeField, Header("Ground Detection")]
    private Transform groundCheck = null;
    private float groundRadius = 0.3f;
    [SerializeField]
    private LayerMask groundLayerMask;
    public bool isGrounded = false;
    private Vector3 jumpVelocity = Vector3.zero;
    private Transform Target = null;
    private Vector3 TargetPrevPos = Vector3.zero;

    // Player Input References
    Vector2 moveVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookVector = Vector2.zero;

    // Components
    Animator animator = null;
    CharacterController characterController = null;

    public readonly int IsRunningHash = Animator.StringToHash("IsRunning");
    public readonly int SwordAttackHash = Animator.StringToHash("SwordAttack");

    //public Transform player;
    public Vector3 OriginScale;

    //[Header("CheckPoint")]
    //public Vector3 StartPos;
    PlayerHealth playerHealth;

    //Sound Manager
    [SerializeField]
    public SoundManagerScript soundManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        OriginScale = transform.localScale;
        playerHealth = GetComponent<PlayerHealth>();
        //characterController = GetComponent<CharacterController>();
        //characterController.detectCollisions
        //StartPos = transform.position;

        //Get soundmanager
        soundManager = FindObjectOfType<SoundManagerScript>();
    }


    void Update()
    {
        // Rotate the camera based on Vector2 values received from PlayerActionMap [[[[[[[[  WiP CAMERA MOVEMENT, CURRENTLY NOT IN USE  ]]]]]]]]]]]]
        //followTarget.transform.rotation *= Quaternion.AngleAxis(lookVector.x * cameraRotationSensitivity * Time.deltaTime, Vector3.up);
        //followTarget.transform.rotation *= Quaternion.AngleAxis(lookVector.y * cameraRotationSensitivity * Time.deltaTime, Vector3.left);
        //var angle = followTarget.transform.localEulerAngles;
        //angle.z = 0;
        //followTarget.transform.localEulerAngles = angle;

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayerMask);

        if (isGrounded && jumpVelocity.y < 0.0f)
        {
            jumpVelocity.y = -2.0f;
        }

        //jumpVelocity.y += Physics.gravity.y * Time.deltaTime;

        // Move the player based on Vector2 values received from PlayerActionMap
        if (!(moveVector.magnitude > 0)) 
            moveDirection = Vector3.zero;

        moveDirection = new Vector3(moveVector.x , 0.0f, moveVector.y);

        if (moveVector != Vector2.zero)
        {
            transform.LookAt(moveDirection + transform.position);
        }

        //if (Target)
        //{
        //    if (TargetPrevPos != Target.position)
        //    {
        //        moveDirection += (Target.position - TargetPrevPos);
        //        TargetPrevPos = Target.position;
        //        Debug.Log("Move");
        //    }
        //}

        transform.position += moveDirection * movementSpeed * Time.deltaTime;
        //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (transform.parent != null)
        {
            transform.localScale = new Vector3(
                OriginScale.x / transform.parent.localScale.x,
                OriginScale.y / transform.parent.localScale.y,
                OriginScale.z / transform.parent.localScale.z);

            Debug.Log(OriginScale.x / transform.parent.localScale.x);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        //if (Target)
        //{
        //    if (TargetPrevPos != Target.position)
        //    {
        //        moveDirection += (Target.position - TargetPrevPos);
        //        TargetPrevPos = Target.position;
        //        Debug.Log("Move");
        //    }
        //}

        //Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);
        //characterController.Move(movementDirection);

        //// Apply Jump
        //jumpVelocity.y += Physics.gravity.y * Time.deltaTime;
        //characterController.Move(jumpVelocity * Time.deltaTime);

        //// Rotate the player to face direction of movement
        //if (moveVector != Vector2.zero) {
        //    transform.LookAt(moveDirection + transform.position);
        //}
    }


    // Receive Input Actions, these functions are called when the PlayerInput component makes a corrisponding broadcast
    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
        
        // Update movement animation
        if (moveVector != Vector2.zero)
        {
            animator.SetBool(IsRunningHash, true);

            if (!soundManager.playerRunGrassSFX.isPlaying)
                soundManager.PlayPlayerRunGrassSFX();
        }
        else
        {
            animator.SetBool(IsRunningHash, false);
            soundManager.StopPlayerRunGrassSFX();
        }
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (!isGrounded) return; // Restrict  to single jump

        Debug.Log("Jump");
        // Set jump velocity
        //jumpVelocity.y = Mathf.Sqrt(jumpForce * -2.0f * Physics.gravity.y);
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);

        //Play Jump SFX
        soundManager.PlayPlayerJumpSFX();

        // TODO ADD JUMP ANIMATION
    }

    public void OnSwordAttack(InputValue value)
    {
        animator.SetTrigger(SwordAttackHash);

        //Play SFX for attacking
        soundManager.PlayPlayerAttackSFX();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    // Check Collision
    private void OnCollisionEnter(Collision collision)
    {
        // The player can get onto the platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Hit Enter");
            //Target = collision.transform;
            //TargetPrevPos = Target.position;
            transform.SetParent(collision.transform);

        }
        if (collision.gameObject.CompareTag("TurtleShell"))
        {
            Debug.Log("TurtleShell collision");
            playerHealth.TakeDamage(5);

            //Play Hurt SFX
            soundManager.PlayPlayerDamagedSFX();
        }
    }

    // Check Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Hit Finish");
            SceneManager.LoadScene("WinScene");
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Hit Spike");
            // ? playerHealth.TakeDamage(1);

            //Play SFX for getting hurt
            soundManager.PlayPlayerDamagedSFX();
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        // The player is no longer afftected by platform's transform.
        if (other.gameObject.CompareTag("Platform"))
        {
            Target = null;
            transform.SetParent(null);
        }
    }
}
