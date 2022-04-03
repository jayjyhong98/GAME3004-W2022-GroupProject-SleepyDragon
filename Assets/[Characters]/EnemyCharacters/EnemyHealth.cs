using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private EnemyBehaviour enemy;
    public EnemyBehaviour Enemy { get { return enemy; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Debug.Log("hello??????????????????????????????????????????");
            enemy.TakeDamage(1);

        }
    }
}
