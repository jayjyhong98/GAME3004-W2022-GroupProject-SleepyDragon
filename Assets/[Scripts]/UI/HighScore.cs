//*********************************************************************************************************
//Author: Mariam Ogunlesi
//
// Last Modified: April 3, 2022
//  
// Description: This script is used to get High score.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The HighScoreManager class
/// </summary>
public class HighScore : MonoBehaviour
{
    //References
    public TextMeshProUGUI FinalScore;

    private int TScore = ScoreCounter.scoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        if (FinalScore)
        {

            string v = string.Format("{0}", TScore);
            FinalScore.text = v;
        }
    }

    
}
