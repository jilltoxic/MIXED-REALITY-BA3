using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLoader : MonoBehaviour
{
    public float counter;
    public float LoadNextScene;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= LoadNextScene)
        {
            SceneManager.LoadScene("Tutuorial");
        }
    }

}
