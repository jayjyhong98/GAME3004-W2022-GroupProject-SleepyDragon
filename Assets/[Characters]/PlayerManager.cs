using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // A singleton to track to the player, used for enemy AI sensing
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    // TODO : UPDATE THIS SCRIPT FOR WHEN PLAYER SPAWNS
}
