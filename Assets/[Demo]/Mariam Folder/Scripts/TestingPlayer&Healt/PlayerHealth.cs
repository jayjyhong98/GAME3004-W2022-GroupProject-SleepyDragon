using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxhealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;
    private bool isInvulnerable = true;

    void Start()
    {
        if (currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
            healthBar.SetMaxHealth(maxhealth);
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }


        StartCoroutine(GameStartInvulnerability()); //Briefly disables character collision at game start.
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            
        }
    }
    public void TakeDamage(int damage)
    {
        if ((currentHealth - damage) < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        healthBar.SetHealth(currentHealth);
    }

  
        public void AddHealth(int _amount)
    { //add amount of health from inventory screen when seed button is pressed
        if (currentHealth < maxhealth)
        {  //check if health is under max health
            currentHealth += _amount; //add amount to current health
            if (currentHealth > maxhealth)
            { //if health is greater then the max allowed set it to max allowed.
                currentHealth = maxhealth;
            }
        }
        healthBar.SetHealth(currentHealth);
    }

    //Note: Used in loading/saving game
    public void SetHealth(int _amount)
    {
        if (_amount >= maxhealth)
        {
            currentHealth = maxhealth;
            healthBar.SetMaxHealth(maxhealth);
        }
        else if (_amount < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = _amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    //Briefly disables character collision at game start. This is to prevent errors when player decides to load a game where the player character is already colliding with an enemy.
    IEnumerator GameStartInvulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(0.4f);
        isInvulnerable = false;
    }

}
