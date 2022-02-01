using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTriggerController : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform spawnPoint;

    private SpawnController spawnController;
    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.FindObjectOfType<SpawnController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit CheckPoint");
            spawnController.SetCurrentSpawnPoint(spawnPoint);
        }
    }
}
