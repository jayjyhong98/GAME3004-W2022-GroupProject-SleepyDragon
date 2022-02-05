using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public SpawnController spawnController;

    private void Start()
    {
        //spawnController = GameObject.FindObjectOfType<SpawnController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
            //Debug.Log("Hit Death Plane");
            // Spawn player to currentSpawnPoint
            //other.transform.position = spawnController.currentSpawnPoint.position;

            //Debug.Log(other.transform.position);

            //PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();

            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Hit Death Plane");
                // Spawn player to currentSpawnPoint
                other.transform.position = spawnController.currentSpawnPoint.position;
            }

            //--player.Health;

            //if (player.Health == 0)
            //{
            //    //Death
            //}
        //}
        //else
        //{
            //other.gameObject.SetActive(false);
        //}
    }
}
