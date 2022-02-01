//*********************************************************************************************************
// Author: Mingkun Yang
//
// Last Modified: January 31, 2022
//  
// Description: This script is used for the button control and scene Transition of the game.
//
//******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public void OnOptionButtonPressed()
    {
        SceneManager.LoadScene("Option");
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("Demo");
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene("GameOver");
    }
}
