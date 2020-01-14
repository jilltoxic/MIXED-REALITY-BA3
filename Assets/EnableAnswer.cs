using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnswer : MonoBehaviour
{
    public GameObject PanelAnswer;
    public bool IsOn;
    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YesAnswer()
    { if (IsOn == false)
        PanelAnswer.SetActive(true);
        IsOn = true;
    }
    public void NoAnswer()
    { if (IsOn == true)
        PanelAnswer.SetActive(false);
        IsOn = false;
    }
}
