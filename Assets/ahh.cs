using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ahh : MonoBehaviour
{
    Button btn;
    public Location location;
    System.TimeSpan duration;
    int locationID = 2;

    private void Start()
    {
        btn = gameObject.GetComponent<Button>();
        if (location != null)
            locationID = location.locationID;
    }

    public void Do(){
        SceneManager.LoadScene("Item Shop");
    }

    public void Update()
    {
        duration = System.DateTime.FromBinary(CurrentUser.instance.buffs[locationID]) - System.DateTime.Now;
        btn.interactable = duration.TotalSeconds > 0;
    }
}
