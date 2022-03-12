//*********************************************************************************************************
// Author: Pauleen Lam
//
// Last Modified: March 10, 2022
//  
// Description: This script is used to trigger a camera reposition.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRepostioner : MonoBehaviour
{
    [SerializeField]
    private CameraPosition position = CameraPosition.BACK;
    [SerializeField]
    private float xRot = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CameraController")
        {
            Debug.Log("something is colli");
            other.GetComponent<CameraController>().RepositionCamera(position, xRot);
        }
    }
}
