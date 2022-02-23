//*********************************************************************************************************
// Author: Jeongyeon Jane Hong & Pauleen
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement hazard responses.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum HazardType
{
    PIT,
    DAMAGE,
    DEATHPLANE,
    ENEMY
}

public class HazardController : MonoBehaviour
{
    // Spawnpoint
    [SerializeField]
    private SpawnController spawnController;

    // Enum for type of hazard
    [SerializeField]
    private HazardType type = HazardType.DAMAGE;

    // Value for hazard's damage on player
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Pit hazards will send player back to spawnpoint as well as deal damage
            if (type == HazardType.PIT)
            {
                Debug.Log("Fell into pit (water/lava)");
                other.transform.position = spawnController.currentSpawnPoint.position;
                other.GetComponent<PlayerBehaviour>().TakeDamage(damage);
            }

            // Damage hazards will deal damage only
            if (type == HazardType.DAMAGE)
            {
                Debug.Log("Recieved damage!");
                other.GetComponent<PlayerBehaviour>().TakeDamage(damage);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Deathplanes send player back to last spawnpoint and deals significant damage
            if (type == HazardType.DEATHPLANE)
            {
                Debug.Log("Hit Death Plane");
                other.transform.position = spawnController.currentSpawnPoint.position;
                other.gameObject.GetComponent<PlayerBehaviour>().TakeDamage(damage);
            }

            // Enemies damage
            if (type == HazardType.ENEMY)
            {
                Debug.Log("Enemy touch!");
                other.gameObject.GetComponent<PlayerBehaviour>().TakeDamage(damage);
            }
        }
    }
}
