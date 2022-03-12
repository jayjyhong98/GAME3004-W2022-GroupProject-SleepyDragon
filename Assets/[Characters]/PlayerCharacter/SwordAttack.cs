using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private bool attacking = false;
    public bool Attacking { get { return attacking; } }
    private float time = 0.0f;

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else 
        {
            attacking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && attacking)
        {
            Debug.Log("hello??????????????????????????????????????????");
            Destroy(collision.gameObject);
        }
    }

    public void Attack()
    {
        attacking = true;
        time = 1.0f;
    }
}
