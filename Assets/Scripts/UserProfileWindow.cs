using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserProfileWindow : MonoBehaviour
{
    public Text UserNameText, UserTeamText, UserGoldAmountText;
    public TMP_Text rubyScoreText, goldenScoreText;
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

        FirebaseManager.Instance.GetTeamScore(0, this);
        FirebaseManager.Instance.GetTeamScore(1, this);
    }

    public void UpdateTeamScores(int team, int score)
    {
        if (team == 0)
        {
            rubyScoreText.text = score.ToString();
            rubyScoreText.gameObject.SetActive(false);
            rubyScoreText.gameObject.SetActive(true);
        }
        else
        {
            goldenScoreText.text = score.ToString();
            goldenScoreText.gameObject.SetActive(false);
            goldenScoreText.gameObject.SetActive(true);
        }
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

    public void GetPoints()
    {
     
    }

    public void OnLogOutButton()
    {
        FirebaseManager.Instance.LogoutUser();
        SceneManager.LoadScene("LoginScreen");
    }
}
