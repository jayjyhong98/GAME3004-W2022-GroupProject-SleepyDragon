//*********************************************************************************************************
// Author: Jeongyeon Jane Hong
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Lava pit.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    public SpawnController spawnController;

    // Start is called before the first frame update
    void Start()
    {
        //spawnController = GameObject.FindObjectOfType<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("Hit Lava");
        //    other.transform.position = spawnController.currentSpawnPoint.position;
        //    Debug.Log(other.transform.position);
        //}

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Lava");
            // Spawn player to currentSpawnPoint
            other.transform.position = spawnController.currentSpawnPoint.position;
        }
    }
}
