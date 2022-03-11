//*********************************************************************************************************
// Author: Pauleen Lam
//
// Last Modified: March 10, 2022
//  
// Description: This script is used to move the camera based on input or scene.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum CameraPosition
{
    LEFT,
    RIGHT,
    FRONT,
    BACK
}

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private float cameraRotationSensitivity = 30;

    Vector2 lookVector = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYER CAMERA STUFF -----------------------------------------------------------------------------
        transform.position = player.transform.position;
        // Rotate the camera based on Vector2 values received from PlayerActionMap
        transform.rotation *= Quaternion.AngleAxis(lookVector.x * cameraRotationSensitivity * Time.deltaTime, Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(lookVector.y * cameraRotationSensitivity * Time.deltaTime, Vector3.left);
        var angle = transform.localEulerAngles;
        angle.z = 0;
        transform.localEulerAngles = angle;
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }

    public void RepositionCamera(CameraPosition pos, float xRot = 12)
    {
        Quaternion newAngle = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        switch (pos)
        {
            case CameraPosition.LEFT:
                newAngle = Quaternion.Euler(xRot, 90.0f, 0.0f);
                break;
            case CameraPosition.RIGHT:
                newAngle = Quaternion.Euler(xRot, -90.0f, 0.0f);
                break;
            case CameraPosition.FRONT:
                newAngle = Quaternion.Euler(xRot, 180.0f, 0.0f);
                break;
            case CameraPosition.BACK:
                newAngle = Quaternion.Euler(xRot, 0.0f, 0.0f);
                break;
        }

        newAngle.z = transform.rotation.z;

        transform.rotation = newAngle;
    }
}
