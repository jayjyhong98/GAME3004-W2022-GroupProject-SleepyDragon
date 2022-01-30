//*********************************************************************************************************
// Author: Mariam Ogunlesi
//
// Last Modified: January 28, 2022
//  
// Description: Pause Screen.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Demo Menu");
    }
}
