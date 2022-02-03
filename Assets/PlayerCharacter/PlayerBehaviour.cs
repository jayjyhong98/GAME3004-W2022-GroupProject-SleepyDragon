using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField, Header("Player Movement")]
    private float movementSpeed = 8;
    [SerializeField]
    private float jumpForce = 7;
    [SerializeField]
    private float cameraRotationSensitivity = 30;
    private float playerRotationSpeed = 10;

    // Player Jump
    [SerializeField, Header("Ground Detection")]
    private Transform groundCheck = null;
    private float groundRadius = 0.3f;
    [SerializeField]
    private LayerMask groundLayerMask;
    private bool isGrounded = false;

    // Player Input References
    Vector2 moveVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookVector = Vector2.zero;

    // Components
    GameObject followTarget = null;
    Animator playerAnimator = null;
    Rigidbody rigidbody = null;

    public readonly int IsRunningHash = Animator.StringToHash("IsRunning");


    void Start()
    {
        followTarget = GameObject.Find("FollowTarget");
        playerAnimator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
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

        // Restrict moviment when jumping
        //if (!isGrounded) return;

        // Move the player based on Vector2 values received from PlayerActionMap
        if (!(moveVector.magnitude > 0)) moveDirection = Vector3.zero;
        moveDirection = new Vector3(moveVector.x ,0.0f, moveVector.y);
        if(!isGrounded) moveDirection /= 2;
        Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);
        transform.position += movementDirection;

        // Rotate the player to face direction of movement
        if (moveVector != Vector2.zero) {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0.0f, targetAngle, 0.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * playerRotationSpeed);
        }
    }


    // Receive Input Actions, these functions are called when the PlayerInput component makes a corrisponding broadcast
    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();

        // Update movement animation
        if (moveVector != Vector2.zero)
            playerAnimator.SetBool(IsRunningHash, true);
        else
            playerAnimator.SetBool(IsRunningHash, false);
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (!isGrounded) return; // Restrict  to single jump

        isGrounded = false;
        // Apply jump force
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        // TODO ADD JUMP ANIMATION
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
