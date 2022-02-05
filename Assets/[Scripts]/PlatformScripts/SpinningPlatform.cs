//*********************************************************************************************************
// Author: Jeongyeon Jane Hong
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Spinning Platform.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    public float rotateSpeed;
    public SpinningPlatformDirection direction;

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
     
        switch (direction)
        {
            case SpinningPlatformDirection.UP:
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
                break;
            case SpinningPlatformDirection.DOWN:
                transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
                break;
            case SpinningPlatformDirection.FORWARD:
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.World);
                break;
            case SpinningPlatformDirection.BACK:
                transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime, Space.World);
                break;
            case SpinningPlatformDirection.RIGHT:
                transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.World);
                break;
            case SpinningPlatformDirection.LEFT:
                transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime, Space.World);
                break;
        }
    }
}
