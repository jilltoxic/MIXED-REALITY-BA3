using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualScript : MonoBehaviour
{
    [SerializeField]
    GameObject RubyRiderManual;

    [SerializeField]
    GameObject GoldenCircleManual;

    public void OnManualOpen()
    {
        if (RubyRiderManual.active == false && GoldenCircleManual.active == false)
        {
            if (CurrentUser.instance.team == 0)
            {
                RubyRiderManual.SetActive(true);
            }
            else if (CurrentUser.instance.team == 1)
            {
                GoldenCircleManual.SetActive(true);
            }
        }

    }
}
