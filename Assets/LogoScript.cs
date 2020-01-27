using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    [SerializeField]
    GameObject RubyRiderLogo;

    [SerializeField]
    GameObject GoldenCircleLogo;

    public void UpdateLogos()
    {
                       
        if (CurrentUser.instance.team == 0)
        {
            RubyRiderLogo.SetActive(true);
            GoldenCircleLogo.SetActive(false);
        }
        else if (CurrentUser.instance.team == 1)
        {
            GoldenCircleLogo.SetActive(true);
            RubyRiderLogo.SetActive(false);
        }
        
    }
}
