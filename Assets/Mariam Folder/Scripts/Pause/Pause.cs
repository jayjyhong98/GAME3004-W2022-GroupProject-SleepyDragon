//**************************************************************************************************************************************************************************************************************************************
// Author: Mariam Ogunlesi
//
// Last Modified: January 28, 2022
//  
// Description: This script manage pausing the game opposed to more involved methods using Time.
//
//
//  
//
//*******************************************************************************************************************************************************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //Unpause the game on start up
    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    //Toggles game pause
    public void ToggleGamePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }

        Time.timeScale = 0;
    }

    //Sets the whether the game is paused or not.
    public void SetGamePause(bool _set)
    {
        if (_set)
        {
            Time.timeScale = 0;
            return;
        }
        Time.timeScale = 1;
    }

    //Sets the timescale manually
    public void SetTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
    }

    //Returns whether or not the game is paused.
    public bool IsGamePaused()
    {
        if (Time.timeScale == 0)
        {
            return true;
        }
        return false;
    }
}
