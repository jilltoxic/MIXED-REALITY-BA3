using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserProfileWindow : MonoBehaviour
{
    public TMP_Text UserNameText, UserTeamText, UserGoldAmountText, userScoreText;
    public TMP_Text rubyScoreText, goldenScoreText;
    public Image TeamLogo;

    public Slider teamScoreSlider;
    
    void Start()
    {
        UpdateUIValues();
    }

    private void Update()
    {
        if (UI.dirty)
        {
            UpdateUIValues();
            UI.dirty = false;
        }
    }

    // Update is called once per frame
    void UpdateUIValues()
    {
        UserNameText.text = CurrentUser.instance.username;
        UserTeamText.text = CurrentUser.instance.team == 0 ? "Ruby Riders" : "Golden Circle";
        //TeamLogo.color = CurrentUser.instance.team == 0 ? Color.red : Color.green;
        UserGoldAmountText.text = CurrentUser.instance.gold + " SHARDS";
        userScoreText.text = CurrentUser.instance.UserScore.ToString() + "REPUTATION";

        rubyScoreText.text = CurrentTeamScore.instance.RubyRiderScore.ToString();
        goldenScoreText.text = CurrentTeamScore.instance.GoldenCircleScore.ToString();

        teamScoreSlider.value = CalculateRelationOfScores();
    }


    public void GetGold()
    {
        
        FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold + 5).ToString());
    }

    public void SpendGold()
    {
        if (CurrentUser.instance.gold >= 25)
            FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold - 25).ToString());
    }

    //Adds 50 points tpo the selected team
    public void GetPoints(int team)
    {
        if (team == 0)
        {
            CurrentTeamScore.instance.GoldenCircleScore -= 50;
            CurrentTeamScore.instance.RubyRiderScore += 50;
        }
        else
        {
            CurrentTeamScore.instance.GoldenCircleScore += 50;
            CurrentTeamScore.instance.RubyRiderScore -= 50;
        }
        FirebaseManager.Instance.SetTeamScore();
    }

    void SetPoints(int gc, int rr)
    {
        CurrentTeamScore.instance.GoldenCircleScore = gc;
        CurrentTeamScore.instance.RubyRiderScore = rr;
        FirebaseManager.Instance.SetTeamScore();

    }

    public void OnLogOutButton()
    {
        FirebaseManager.Instance.LogoutUser();
        SceneManager.LoadScene("LoginScreen");
    }


    float CalculateRelationOfScores()
    {
        if (CurrentTeamScore.instance.RubyRiderScore + CurrentTeamScore.instance.GoldenCircleScore != 0)
        {
            return (float)CurrentTeamScore.instance.GoldenCircleScore /
                   (float)(CurrentTeamScore.instance.RubyRiderScore + CurrentTeamScore.instance.GoldenCircleScore);
        }
        else
        {
            return 0.5f;
        }
                
    }

    public void BuyItem(int price)
    {
        
    }

    


    // ----------------------------------- DEBUG ---------------------------------
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
}
