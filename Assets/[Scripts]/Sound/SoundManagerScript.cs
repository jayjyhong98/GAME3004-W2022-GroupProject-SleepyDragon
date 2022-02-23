//*********************************************************************************************************
// Author: Phu Pham
//
// Last Modified: February 2, 2022
//  
// Description: This script is used for managing all ingame audio
//
//******************************************************************************************************




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{

    [SerializeField]
    public AudioMixer mixer;
    public AudioSource menuMusic, optionMusic, overworldMusic, victoryMusic, defeatMusic;
    public AudioSource buttonSFX, inventorySFX;
    public AudioSource playerAttackSFX, playerDamagedSFX, playerJumpSFX, playerHealSFX, playerRunGrassSFX;
    public AudioSource enemyAttackSFX, enemyDamagedSFX;
    public float volume = 0f;
    AudioMixerGroup a;


    private string currentScene = "MainMenuScene";

    //Check to see if there's only 1 Manager
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //mixer = GetComponent<AudioMixer>();
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayBGM();
    }

    //Called when a scene is loaded
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        currentScene = scene.name;
        StopAllMusic();
        PlayBGM();
    }

    
    //private AudioSource[] allAudioSources;
    private List<AudioSource> allAudioSources;
    //Stop all music
    void StopAllMusic()
    {

        allAudioSources = new List<AudioSource>(FindObjectsOfType(typeof(AudioSource)) as AudioSource[]);
        allAudioSources.Remove(buttonSFX);
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    //Play a button sound effect
    public void PlayButtonSFX()
    {
        buttonSFX.Play();
    }
    
    public void PlayPlayerAttackSFX()
    {
        playerAttackSFX.Play();
    }

    public void PlayPlayerDamagedSFX()
    {
        playerDamagedSFX.Play();
    }

    public void PlayPlayerJumpSFX()
    {
        playerJumpSFX.Play();
    }

    public void PlayInventorySFX()
    {
        inventorySFX.Play();
    }

    public void PlayPlayerHealSFX() //This is also used for consuming items in inventory
    {
        playerHealSFX.Play();
    }

    public void PlayPlayerRunGrassSFX()
    {
        playerRunGrassSFX.Play();
    }

    public void StopPlayerRunGrassSFX()
    {
        playerRunGrassSFX.Stop();
    }

    //Play a music track depending on current scene
    public void PlayBGM()
    {
        switch (currentScene)
        {
            case "MainMenuScene":
                Debug.Log("menu");
                menuMusic.Play();
                break;
            case "OptionScene":
                Debug.Log("option");
                optionMusic.Play();
                break;
            case "GameOverScene":
                Debug.Log("over");
                defeatMusic.Play();
                break;
            case "GameLevelScene 1":
                Debug.Log("lvl");
                overworldMusic.Play();
                break;
            case "WinScene":
                Debug.Log("win");
                victoryMusic.Play();
                break;
            default:
                Debug.Log("Invalid Scene");
                break;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        //Set game volume
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("musicVolume"));

    }
}
