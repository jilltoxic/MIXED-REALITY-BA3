using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIntroSound : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("UI_Intro");
    }
}
