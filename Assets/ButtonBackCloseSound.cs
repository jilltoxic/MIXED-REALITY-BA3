using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackCloseSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("UI_BackClose");
        
    }
}
