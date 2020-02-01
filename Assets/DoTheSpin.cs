using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTheSpin : MonoBehaviour
{
    public float spinnX;
    public float spinnY;
    public float spinnZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinnX * Time.deltaTime, spinnY*Time.deltaTime, spinnZ * Time.deltaTime);
    }
}
