using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTutorialSounds : MonoBehaviour
{
    void OnAwake()
    {
        FindObjectOfType<AudioManager>().Play("UI_Tutorial");
    }
}
