using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardEntry : MonoBehaviour
{
    public TMP_Text namefield;
    public TMP_Text scorefield;
    
    public void SetField(string name, string score)
    {
        namefield.text = name;
        scorefield.text = score;
    }
}
