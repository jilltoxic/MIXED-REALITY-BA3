using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextDisplayer : MonoBehaviour
{
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public GameObject Story5;
    public GameObject Story6;
    private float counter;
    public float Story1Start;
    public float Story2Start;
    public float Story3Start;
    public float Story4Start;
    public float Story5Start;
    public float Story6Start;
    public float ChangeScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= Story1Start && counter <= Story2Start)
        {
            Story1.SetActive(true);
        }

        else if(counter >= Story2Start && counter <= Story3Start)
        {
            Story1.SetActive(false);
            Story2.SetActive(true);
        }
        else if (counter >= Story3Start && counter <= Story4Start)
        {
            Story2.SetActive(false);
            Story3.SetActive(true);
        }
        else if (counter >= Story4Start && counter <= Story5Start)
        {
            Story3.SetActive(false);
            Story4.SetActive(true);
        }
        else if (counter >= Story5Start && counter <= Story6Start)
        {
            Story4.SetActive(false);
            Story5.SetActive(true);
        }
        else if (counter >= Story6Start && counter <= ChangeScene)
        {
            Story5.SetActive(false);
            Story6.SetActive(true);
        }
        else if (counter >= ChangeScene)
        {
            SceneManager.LoadScene("LoginScreen");   
        }
    }
}
