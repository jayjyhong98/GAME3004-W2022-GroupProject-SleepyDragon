//*********************************************************************************************************
// Author: Pauleen Lam
//
// Last Modified: March 12, 2022
//  
// Description: Activates the sword to apply damage on enemies
//
//******************************************************************************************************
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
        // Countdown only when sword is active for attacking
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else 
        {
            // if countdown reaches zero, deactivate damage.
            attacking = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // when colliding with an enemy, apply damage if attacking is active
        if (collision.gameObject.CompareTag("Enemy") && attacking)
        {
            collision.gameObject.GetComponentInParent<EnemyBehaviour>().TakeDamage(damage);
        }
    }

    // Called by the player when attack button is pressed. Will start attack active countdown
    public void Attack()
    {
        attacking = true;
        time = 1.0f;
    }
}
