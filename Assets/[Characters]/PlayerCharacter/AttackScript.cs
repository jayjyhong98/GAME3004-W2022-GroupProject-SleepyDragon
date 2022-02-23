using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
                Debug.Log("Damage the enemy somehow");
                other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }
    }
}
