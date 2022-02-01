//*********************************************************************************************************
// Author: Mariam Ogunlesi
//
// Last Modified: January 28, 2022
//  
// Description: This script is used for the main UI control and scene Transition of the game.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLoadClick()
    {
    }

}
