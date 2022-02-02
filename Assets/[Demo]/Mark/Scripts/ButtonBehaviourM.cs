//*********************************************************************************************************
// Author: Mingkun Yang, Phu Pham
//
// Last Modified: February 2, 2022
//  
// Description: This script is used to implement volume slider function.
//
//******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviourM : MonoBehaviour
{
    public SoundManagerScript soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManagerScript>();
    }

    public void OnOptionButtonPressed()
    {
        soundManager.PlayButtonSFX();
        SceneManager.LoadScene("OptionScene");
        
    }
    public void OnNewGameButtonPressed()
    {
        soundManager.PlayButtonSFX();
        SceneManager.LoadScene("Demo");
    }

    public void OnExitButtonPressed()
    {
        soundManager.PlayButtonSFX();
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        soundManager.PlayButtonSFX();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnRestartButtonPressed()
    {
        soundManager.PlayButtonSFX();
        SceneManager.LoadScene("Demo");
    }

    public void OnNextButtonPressed()
    {
        soundManager.PlayButtonSFX();
        SceneManager.LoadScene("GameOverScene");
    }
}
