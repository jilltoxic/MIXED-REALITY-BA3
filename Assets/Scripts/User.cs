using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public string email;
    public string userID;
    public int team;
    public int gold;
    public int[] items;
    public int card;
    public int userScore;
    public int UserScore
    {
        set
        {
            int dif = value - userScore;
            userScore = value;
            FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "userScore", CurrentUser.instance.UserScore.ToString());
            FirebaseManager.Instance.SetOwnTeamScore(dif);
        }
        get { return userScore; }
    }

    public User()
    {
    }

    public User(string username, string email, string userID)
    {
        this.username = username;
        this.email = email;
        this.userID = userID;
    }

    public User(string username, string email, string userID, int gold)
    {
        this.username = username;
        this.email = email;
        this.userID = userID;
        this.gold = gold;
    }
}

public static class CurrentUser
{
    public static User instance;
}

