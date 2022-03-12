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
    public AudioSource playerAttackSFX, playerDamagedSFX, playerJumpSFX, playerPickupSFX, playerHealSFX, playerRunGrassSFX;
    public AudioSource enemyAttackSFX, enemyDamagedSFX;
    public AudioSource lavaPitLoopSFX, lavaPitDamageSFX, spikesDamageSFX, swingAxeSFX, rollingGrinderLoopSFX, rollingGrinderDamageSFX;
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

    //UI SOUND EFFECTS
    public void PlayButtonSFX() //Buttons sfx
    {
        buttonSFX.Play();
    }
    
    //PLAYER SOUND EFFECTS
    public void PlayPlayerAttackSFX()   //Attacks sfx
    {
        playerAttackSFX.Play();
    }

    public void PlayPlayerDamagedSFX()  //Player hurt sfx
    {
        playerDamagedSFX.Play();
    }

    public void PlayPlayerJumpSFX()     //Jumping sfx
    {
        playerJumpSFX.Play();
    }

    public void PlayPlayerPickupSFX()   //Picking up item sfx
    {
        playerPickupSFX.Play();
    }

    public void PlayInventorySFX()      //Opening/Closing inventory
    {
        inventorySFX.Play();
    }

    public void PlayPlayerHealSFX()     //Healing/Consuming items
    {
        playerHealSFX.Play();
    }

    public void PlayPlayerRunGrassSFX() //Looping sfx for running
    {
        playerRunGrassSFX.Play();
    }

    public void StopPlayerRunGrassSFX() //Stop the running sfx loop
    {
        playerRunGrassSFX.Stop();
    }

    //ENEMY SOUND EFFECTS
    public void PlayEnemyAttackSFX()    //Enemy attacks
    {
        enemyAttackSFX.Play();
    }

    public void PlayEnemyHurtSFX()      //Enemy getting hurt
    {
        enemyDamagedSFX.Play();
        Debug.Log("Play Enemy Damage Sound");
    }


    //HAZARDS SOUND EFFECTS
    public void PlayLavaPitLoopSFX()    //Lava pit loop, meant to be constantly play when pit is created
    {
        lavaPitLoopSFX.Play();
        Debug.Log("Play Lava Loop Sound");
    }

    public void PlayLavaPitDamageSFX()  //Played when lava pit damage player
    {
        lavaPitDamageSFX.Play();
        Debug.Log("Play Lava Damage Sound");
    }

    public void PlaySpikePitDamageSFX() //Played when spike pit damage player
    {
        spikesDamageSFX.Play();
    }

    public void PlaySwingAxeSFX()       //Play when the axe swings
    {
        swingAxeSFX.Play();
        Debug.Log("Play Swing Loop Sound");
    }

    public void PlayRollingGrinderLoopSFX()//Grinder loop, constantly play after grinder is created
    {
        rollingGrinderLoopSFX.Play();
        Debug.Log("Play Grinder Loop Sound");
    }


    //public void PlayRollingGrinderDamageSFX()
    //{
    //    rollingGrinderDamageSFX.Play();
    //}

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
