using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    public Transform currentSpawnPoint;

    void Start()
    {
        player.position = currentSpawnPoint.position;
    }
    public void SetCurrentSpawnPoint(Transform newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }
}
