using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyingBehaviour : MonoBehaviour

{

    private float counter;
    public float TimeUntilDestroyable;
    public GameObject IntroSound;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= TimeUntilDestroyable)
        {
            SceneManager.MoveGameObjectToScene(IntroSound, SceneManager.GetActiveScene());
        }
    }
}
