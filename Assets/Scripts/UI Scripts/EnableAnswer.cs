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

    public void Answer()
    { if (IsOn == false)
        {
            PanelAnswer.SetActive(true);
            IsOn = true;
        }
      else if (IsOn == true)
        {
            PanelAnswer.SetActive(false);
            IsOn = false;
        }
    }
}
