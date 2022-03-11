using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotationController : MonoBehaviour
{
    [Header("Biscuit Rotation Speed")]
    public float rotateSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}
