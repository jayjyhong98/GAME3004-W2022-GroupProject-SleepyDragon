//*********************************************************************************************************
//Author: Mariam Ogunlesi
//
// Last Modified: April 3, 2022
//  
// Description: This script is used to add score.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The ScoreCounter class
/// </summary>
public class ScoreCounter : MonoBehaviour
{
    //References
    static public int scoreAmount;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("{0}", scoreAmount);
    }
}
