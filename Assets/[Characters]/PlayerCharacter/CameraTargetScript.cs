using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    Vector2 lookVector = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        //// Rotate the camera based on Vector2 values received from PlayerActionMap [[[[[[[[  WiP CAMERA MOVEMENT, CURRENTLY NOT IN USE  ]]]]]]]]]]]]
        //followTarget.transform.rotation *= Quaternion.AngleAxis(lookVector.x * cameraRotationSensitivity * Time.deltaTime, Vector3.up);
        //followTarget.transform.rotation *= Quaternion.AngleAxis(lookVector.y * cameraRotationSensitivity * Time.deltaTime, Vector3.left);
        //var angle = followTarget.transform.localEulerAngles;
        //angle.z = 0;
        //followTarget.transform.localEulerAngles = angle;
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
        Debug.Log(lookVector);
    }



}
