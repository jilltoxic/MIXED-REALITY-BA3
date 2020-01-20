using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIndicator : MonoBehaviour
{
    public GameObject SliderLeft;
    public GameObject SliderLeftMiddle;
    public GameObject SliderRightMiddle;
    public GameObject SliderRight;
    private int indicator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        indicator = FindObjectOfType<PageSwiper>().swipeCount;

        if (indicator == -1)
        {
            SliderLeft.SetActive(true);
            SliderLeftMiddle.SetActive(false);
            SliderRightMiddle.SetActive(false);
            SliderRight.SetActive(false);
        }
        else if (indicator == 0)
        {
            SliderLeft.SetActive(false);
            SliderLeftMiddle.SetActive(true);
            SliderRightMiddle.SetActive(false);
            SliderRight.SetActive(false);
        }
        else if (indicator == 1)
        {
            SliderLeft.SetActive(false);
            SliderLeftMiddle.SetActive(false);
            SliderRightMiddle.SetActive(true);
            SliderRight.SetActive(false);
        }
        else if (indicator == 2)
        {
            SliderLeft.SetActive(false);
            SliderLeftMiddle.SetActive(false);
            SliderRightMiddle.SetActive(false);
            SliderRight.SetActive(true);
        }
    }
}
