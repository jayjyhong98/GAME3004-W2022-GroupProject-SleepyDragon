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
                Debug.Log("Fell into pit (water/lava)");
                other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }
    }
}
