using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetRemainingLocationTime : MonoBehaviour
{
    public Location location;
    public TMP_Text textFieldRemainingTime; 
    System.TimeSpan duration;
    public GameObject childObject;

    public GameObject noLocationsText;


    // Update is called once per frame
    void Update()
    {
        duration = CurrentUser.instance.buffs[location.locationID] != 0 ? System.DateTime.FromBinary(CurrentUser.instance.buffs[location.locationID]) - System.DateTime.Now : new System.TimeSpan(0);
        childObject.SetActive(duration.TotalSeconds > 0);
        
        textFieldRemainingTime.text = "Remaining Time: " + duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00") + ":" + duration.Seconds.ToString("00");
    }
}
