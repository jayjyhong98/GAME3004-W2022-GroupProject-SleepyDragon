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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        OriginPos = transform.position;
        rigidbody.isKinematic = true;

        BoxCollider[] Arr = GetComponents<BoxCollider>();

        for(int i = 0; i < Arr.Length; ++i)
        {
            if (Arr[i].size.y < 0.3f)
            {
                FallBox = Arr[i];
                Debug.Log("Find");
                break;
            }
        }
    }

    void FallPlatform()
    {
        //rigidbody.bodyType = RigidbodyType.Dynamic;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        Invoke("ResetPlatform", destroySec);

        BoxCollider[] Arr = GetComponents<BoxCollider>();

        for (int i = 0; i < Arr.Length; ++i)
        {
            Arr[i].enabled = false;
        }
    }

    void ResetPlatform()
    {
        transform.position = OriginPos;
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;

        BoxCollider[] Arr = GetComponents<BoxCollider>();

        for (int i = 0; i < Arr.Length; ++i)
        {
            Arr[i].enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player" && collision.collider.Equals(FallBox))
        {
            Invoke("FallPlatform", fallSec);
        }
    }
}
