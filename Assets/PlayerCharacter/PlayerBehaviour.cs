using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    // Player Movement References
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;
        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }

    // Receive Input Actions
    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        Debug.Log(inputVector);
    }
}
