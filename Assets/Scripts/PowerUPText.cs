﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUPText : MonoBehaviour
{
    public TMP_Text DialogueText;
    public int currentPowerUp;

    public TimerScript timer;

   

    // Start is called before the first frame update
    void Start()
    {
        currentPowerUp = Random.Range(0, 15);
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentPowerUp == 0)
        {
            DialogueText.text = "If you are wearing a pair of jeans, you can let all of your opponents items misfunction when used, by saying the spell 'creprius'";
        }
        else if (currentPowerUp == 1)
        {
            DialogueText.text = "If you are wearing a red kind of clothing, you are allowed to steal your opponents items on use and use it for yourself in the battle. (works only once per battle)";
        }
        else if (currentPowerUp == 2)
        {
            DialogueText.text = "You are allowed to turn down prompts saying the spell 'vilis' (does not work on shields)";
        }
        else if (currentPowerUp == 3)
        {
            DialogueText.text = "You are allowed to turn down prompts saying the spell 'futue te ipsum' (also works on shields)";
        }
        else if (currentPowerUp == 4)
        {
            DialogueText.text = "Using your finger gun and saying 'pew pew', you are allowed to attack a player that is in the City Hall, or while beeing in the City Hall yourself";
        }
        else if (currentPowerUp == 5)
        {
            DialogueText.text = "If you loose a battle you are allowed to replay it once, using the spell 'non hodie satan!'";
        }
        else if (currentPowerUp == 6)
        {
            DialogueText.text = "If you wear boots, you are allowed to flee in the middle of any battle using a subtle scream";
        }
        else if (currentPowerUp == 7)
        {
            DialogueText.text = "If you are wearing a hat, you are allowed to take a look at the item stock of any player at any time.";
        }
        else if (currentPowerUp == 8)
        {
            DialogueText.text = "With this buff, you are allowed to check if wether any player is logged into the power up station, and which buff they recieved.";
        }
        else if (currentPowerUp == 9)
        {
            DialogueText.text = "If a player knows you recieved this buff they can prompt you at any time even in the City Hall or while they are in the City Hall themselves.";
        }
        else if (currentPowerUp == 10)
        {
            DialogueText.text = "If a player knows that you recieved this buff they can use one of your items while beeing in a battle with you";
        }
        else if (currentPowerUp == 11)
        {
            DialogueText.text = "If you are wearing a big coat, you can not be attacked by another player.";
        }
        else if (currentPowerUp == 12)
        {
            DialogueText.text = "If players knows you recieved this buff, they can winn any battle against you using the spell 'et potator'";
        }
        else if (currentPowerUp == 13)
        {
            DialogueText.text = "With this buff, you are allowed to attack a person, though they are using a shield.";
        }
        else if (currentPowerUp == 14)
        {
            DialogueText.text = "With this buff you are allowed to take over any ongoing battle.";
        }
        else if (currentPowerUp == 15)
        {
            DialogueText.text = "With this buff you are allowed to break up any ongoing battle by performing a hustle dance.";
        }

    }

}

