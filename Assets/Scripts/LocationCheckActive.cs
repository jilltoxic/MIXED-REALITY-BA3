using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LocationCheckActive : MonoBehaviour
{
    private List<GetRemainingLocationTime> locationTimes;

    [SerializeField]
    private GameObject noLocationsText;


    

    void Start()
    {
        locationTimes = new List<GetRemainingLocationTime>();
        locationTimes = FindObjectsOfType<GetRemainingLocationTime>().ToList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAllLocations()
    {
        StartCoroutine(WaitAFrame());
    }

    IEnumerator WaitAFrame()
    {
        yield return null;
        bool allLocationsInactive = true;
        locationTimes = new List<GetRemainingLocationTime>();
        locationTimes = FindObjectsOfType<GetRemainingLocationTime>().ToList();
        Debug.Log("--------");
        foreach (GetRemainingLocationTime time in locationTimes)
        {
            Debug.Log(time.isActive);
            if (time.isActive)
            {
                allLocationsInactive = false;
                break;
            }
        }

        if (allLocationsInactive)
        {
            noLocationsText.SetActive(true);
        }
        else
        {
            noLocationsText.SetActive(false);
        }
    }
}
