using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GetGoldInBattle : MonoBehaviour,
                                            ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold + 10).ToString());
        }

    }

}
