using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerStationDialogueText : MonoBehaviour
{
    public TMP_Text DialogueText;
    public int NumberOfText;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfText = Random.Range(0, 9);
    }

    void OnAwake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfText == 0)
        {
            DialogueText.text = "Welcome, welcome I hope you still have all your springs and screws!";
        }
        else if (NumberOfText == 1)
        {
            DialogueText.text = "For information on risks and side-effects please read the pack insert and ask your doctor or pharmacist";
        }
        else if (NumberOfText == 2)
        {
            DialogueText.text = "You know the last person that has been here was wearing a big hat. I thought they look dashing!";
        }
        else if (NumberOfText == 3)
        {
            DialogueText.text = "Earlier today I was seeing a fella wearing a big coat. Do you think that would look good on me?";
        }
        else if (NumberOfText == 4)
        {
            DialogueText.text = "Hi, I am Jenkins how may I be of your service?";
        }
        else if (NumberOfText == 5)
        {
            DialogueText.text = "I swear to the Big Council, if another one of those dogs pisses on my station again I am going to send an electric shock!";
        }
        else if (NumberOfText == 6)
        {
            DialogueText.text = "Isn‘t it a lovely day for just standing around in the middle of town and waiting for people to interact with you?";
        }
        else if (NumberOfText == 7)
        {
            DialogueText.text = "I am so bored. Tell me something about the Witches? Or are you a Rider? Doesn’t matter just tell me something!";
        }
        else if (NumberOfText == 8)
        {
            DialogueText.text = "I have heard that someone cracked the code. What code are you asking? I wouldn‘t know I have just heard it.";
        }
        else if (NumberOfText == 9)
        {
            DialogueText.text = "Did you know that a flock of crows is called a murder? That’s what happened last night on the streets over some Shards!";
        }
    }
}


