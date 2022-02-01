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

    [Header("Origin Position")]
    Vector3 OriginPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        OriginPos = transform.position;
    }

    void FallPlatform()
    {
        //rigidbody.bodyType = RigidbodyType.Dynamic;
        rigidbody.isKinematic = true;
    }

    void ResetPlatform()
    {
        transform.position = OriginPos;
        rigidbody.isKinematic = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("FallPlatform", fallSec);
            Invoke("ResetPlatform", destroySec);
        }
    }
}
