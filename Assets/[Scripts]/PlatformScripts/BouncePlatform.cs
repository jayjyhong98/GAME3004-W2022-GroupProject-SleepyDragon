//*********************************************************************************************************
// Author: Jeongyeon Jane Hong
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Bounce Platform.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [Header("Bounce")]
    public float bounce;

    // Start is called before the first frame update
    void Start()
    {
        bounce = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
        }
    }
}
