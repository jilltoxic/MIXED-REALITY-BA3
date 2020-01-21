using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownScript : MonoBehaviour
{
    [SerializeField]
    private float cooldownTime;

    public float lastTimeUsedPowerUp;
    public float lastTimeUsedShop;
    public float lastTimeUsedSaveZone;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastTimeUsedPowerUp + cooldownTime)
        {

        }
    }
}
