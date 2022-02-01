using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JanePlayer : MonoBehaviour
{
    Rigidbody rigidbody;
    public int Health;
    public float jumpForce = 30.0f;
    public Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Health = 5;
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigidbody.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            //transform.SetParent(other.transform);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Hit Spike");
            --Health;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Hit Finish");
            SceneManager.LoadScene("JaneGameWinDemo");
        }

        if (other.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Hit Lava");
            --Health;
            transform.position = StartPos;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //transform.SetParent(null);
        }
    }
}
