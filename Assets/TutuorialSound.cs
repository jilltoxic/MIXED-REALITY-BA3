using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutuorialSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Tutuorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
