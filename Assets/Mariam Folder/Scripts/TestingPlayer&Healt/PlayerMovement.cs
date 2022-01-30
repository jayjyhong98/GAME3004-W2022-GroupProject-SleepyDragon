using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera camController;
    public Transform lockOn;
    public Camera cam;
    // running speed
    public float speed;
    // Camera speed
    public float camSpeed = 20;
    public Vector3 camOffset;

    // jumping power
    public float jumpForce;

    public Rigidbody rb;
    public bool grounded;
    public float sensitivity;

    Vector3 moveDirection;

    float horizontal;
    float vertical;
    public float turnSmoothVelocity;
    public float turnSmoothTime;
    public float angle;
    Animator anim;
    [SerializeField] bool isMoving;

    /// Events
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        lockOn.position = transform.position;

       
            Controls();
        
      

    }


    void Controls()
    {
    

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }



        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            angle -= 125 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle += 125 * Time.deltaTime;
        }
        // Side to Side Movemnt
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

        // Forward and Back movement
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }

        moveDirection = new Vector3(horizontal, 0, vertical);

        float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, smoothedAngle, 0);

        if (isMoving)
        {


            Vector3 moveDir = gameObject.transform.forward * vertical;
            transform.position += moveDir * speed * Time.deltaTime;
        }
        else
        {
        }
    }

    

   
    public void Jump()
    {

        if (grounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }

    // Added OnCollisionStay as I was getting inconsistent collision with imported assets
    // Also added Ground tag so you aren't able to jump along walls
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

   
}
