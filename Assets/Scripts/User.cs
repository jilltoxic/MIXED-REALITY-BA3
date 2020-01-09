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
    public int userScore;
    public int[] items;
    public int card;

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

