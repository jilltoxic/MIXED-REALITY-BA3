using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTheSpin : MonoBehaviour
{
    public float spinn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinn*Time.deltaTime, 0);
    }
}
