//*********************************************************************************************************
// Author: Jeongyeon Jane Hong
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Collapsing Platform.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    [Header("Time")]
    public float fallSec;
    public float destroySec;

    [Header("Platform")]
    private Rigidbody rigidbody;

    private BoxCollider FallBox;

    [Header("Origin Position")]
    Vector3 OriginPos;

    public bool isFall;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        OriginPos = transform.position;
        rigidbody.isKinematic = true;
        isFall = false;

        //BoxCollider[] Arr = GetComponents<BoxCollider>();

        //for(int i = 0; i < Arr.Length; ++i)
        //{
        //    if (Arr[i].size.y < 0.3f)
        //    {
        //        FallBox = Arr[i];
        //        Debug.Log("Find");
        //        break;
        //    }
        //}
    }

    //void Update()
    //{
    //    if (isFall)
    //    {
    //        destroySec += Time.deltaTime;
    //        if (destroySec >= fallSec)
    //        {
    //            Destroy(this);
    //        }
    //    }
    //}

    void FallPlatform()
    {
        //rigidbody.bodyType = RigidbodyType.Dynamic;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        Invoke("ResetPlatform", destroySec);

        //BoxCollider[] Arr = GetComponents<BoxCollider>();

        //for (int i = 0; i < Arr.Length; ++i)
        //{
        //    Arr[i].enabled = false;
        //}
    }

    void ResetPlatform()
    {
        transform.position = OriginPos;
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;

        //BoxCollider[] Arr = GetComponents<BoxCollider>();

        //for (int i = 0; i < Arr.Length; ++i)
        //{
        //    Arr[i].enabled = true;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Invoke("FallPlatform", fallSec);
        }

        //if (collision.gameObject.tag == "Player")
        //{
        //    isFall = true;
        //}
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isFall = false;
    //        destroySec = 0;
    //        Instantiate(this, OriginPos, Quaternion.identity);
    //    }
    //}
}
