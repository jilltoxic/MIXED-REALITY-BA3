using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogShopTexts : MonoBehaviour
{
    public TMP_Text DialogueText;
    public int NumberOfText;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfText = Random.Range(0, 7);
    }

    void OnAwake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfText == 0)
        {
            DialogueText.text = "Welcome, welcome. Come in, take a look and buy something.";
        }
        else if (NumberOfText == 1)
        {
            DialogueText.text = "The last of you fellas brought in this Shard. Look at it! Do you want it? Only 900 Bolts.";
        }
        else if (NumberOfText == 2)
        {
            DialogueText.text = "Did you know that this was the first shop that opened in the Lab? I can‘t believe it has already been that long.";
        }
        else if (NumberOfText == 3)
        {
            DialogueText.text = "I can seriously not understand why you are all so fixated on finding that Juggernaut. Look at those they look exactly the same and you can be the owner for only 10 Bolts!";
        }
        else if (NumberOfText == 4)
        {
            DialogueText.text = "Come in. Are you looking for something special?";
        }
        else if (NumberOfText == 5)
        {
            DialogueText.text = "I probably shouldn‘t tell you, but the guy that owned this place before me left the city without a word. Leaving everything for me.";
        }
        else if (NumberOfText == 6)
        {
            DialogueText.text = "When I was younger and didn‘t sell Shards for a living I used to study nutritional sciences but then all the cornfields went to flames and everything else happened.But I can tell from here that you need more fibers in your diet!";
        }
        else if (NumberOfText == 7)
        {
            DialogueText.text = "As a former engineer I can tell you that you should use the PT-894 instead of the FX-1600 for that improvement. You can find it in the back there somewhere.";
        }
    }
}
