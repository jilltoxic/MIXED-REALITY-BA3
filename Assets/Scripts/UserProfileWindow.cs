using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserProfileWindow : MonoBehaviour
{
    public Text UserNameText, UserTeamText, UserGoldAmountText;
    public Image TeamLogo;

    void Start()
    {
        SetValues();
    }

    private void Update()
    {
        if (CurrentUser.instance.dirtyFlag)
            SetValues();
    }

    // Update is called once per frame
    void SetValues()
    {
        UserNameText.text = CurrentUser.instance.username;
        UserTeamText.text = CurrentUser.instance.team == 0 ? "Ruby Riders" : "Witches";
        TeamLogo.color = CurrentUser.instance.team == 0 ? Color.red : Color.green;
        UserGoldAmountText.text = CurrentUser.instance.gold + " Gold";
    }

    public void GetGold()
    {
        FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "Gold", (CurrentUser.instance.gold + 5).ToString());
    }

    public void SpendGold()
    {
        if (CurrentUser.instance.gold >= 25)
            FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "Gold", (CurrentUser.instance.gold - 25).ToString());
    }
}
