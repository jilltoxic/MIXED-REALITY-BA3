using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    CooldownScript cooldown;
    List<Location> locations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScannedLocation()
    {
        FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold + 5).ToString());
        
    }

    public void OnLostGame()
    {
        //Important: Capital U in UserScore <-- Change Property, not variable
        if (CurrentUser.instance.UserScore >= 20)
            CurrentUser.instance.UserScore -= 20;
        else CurrentUser.instance.UserScore = 0;
    }

    public void OnWonGame()
    {
        //Important: Capital U in UserScore <-- Change Property, not variable
        CurrentUser.instance.UserScore += 20;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("UI");
    }
}
