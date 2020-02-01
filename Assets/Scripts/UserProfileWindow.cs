using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserProfileWindow : MonoBehaviour
{
    public TMP_Text UserNameText, UserTeamText, UserGoldAmountText, userScoreText;
    public TMP_Text anotherUserGoldAmountText;
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
            foreach(InventoryScript IS in FindObjectsOfType<InventoryScript>())
            {
                IS.UpdateInventoryUI();
            }
            
            UI.dirty = false;
        }
    }

    // Update is called once per frame
    void UpdateUIValues()
    {
        UserNameText.text = CurrentUser.instance.username;
        UserTeamText.text = CurrentUser.instance.team == 0 ? "RUBY RIDERS" : "GOLDEN CIRCLE";
        UserTeamText.color = CurrentUser.instance.team == 0 ? new Color32(14,154,26, 255) : new Color32(174,69,153, 255);
        UserGoldAmountText.text = CurrentUser.instance.gold.ToString();
        anotherUserGoldAmountText.text = CurrentUser.instance.gold.ToString();

        userScoreText.text = CurrentUser.instance.UserScore.ToString() + "RP";

        rubyScoreText.text = CurrentTeamScore.instance.RubyRiderScore.ToString();
        goldenScoreText.text = CurrentTeamScore.instance.GoldenCircleScore.ToString();

        teamScoreSlider.value = CalculateRelationOfScores();
        FindObjectOfType<LogoScript>().UpdateLogos();
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



    


    // ----------------------------------- DEBUG ---------------------------------
    public void OnLostGame()
    {
        //Important: Capital U in UserScore <-- Change Property, not variable
        if (CurrentUser.instance.UserScore >= 10)
            CurrentUser.instance.UserScore -= 10;
        else CurrentUser.instance.UserScore = 0;
        FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold + 10).ToString());
    }

    public void OnWonGame()
    {
        //Important: Capital U in UserScore <-- Change Property, not variable
        CurrentUser.instance.UserScore += 10;
        FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "gold", (CurrentUser.instance.gold + 10).ToString());
    }
}
