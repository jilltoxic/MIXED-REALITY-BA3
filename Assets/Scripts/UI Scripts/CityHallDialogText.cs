using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityHallDialogText : MonoBehaviour
{
    public TMP_Text DialogueText;
    public int NumberOfText;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfText = Random.Range(0, 2);
    }

    void OnAwake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfText == 0)
        {
            DialogueText.text = "Come in. What are you looking for?";
        }
        else if (NumberOfText ==1)
        {
            DialogueText.text = "No Fighting allowed!";
        }
        else if (NumberOfText ==2)
        {
            DialogueText.text = "The Big Council is watching you";
        } 
    }
}
