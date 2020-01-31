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
    public List<string> inventory;
    //public Dictionary<string, long> buffs;
    public List<long> buffs;
    public int randomPowerUp;
    public int card;
    public int userScore;
    public int UserScore
    {
        set
        {
            int dif = value - userScore;
            userScore = value;
            FirebaseManager.Instance.UpdateUserValue(CurrentUser.instance, "userScore", CurrentUser.instance.UserScore);
            FirebaseManager.Instance.SetOwnTeamScore(dif);
        }
        get { return userScore; }
    }

    void InitLists()
    {
        inventory = new List<string>();
        buffs = new List<long>();// new Dictionary<string, long>(); //<Location, System.DateTime>();
        buffs.Add(new System.DateTime(1970,1,1).ToBinary());
        buffs.Add(new System.DateTime(1970,1,1).ToBinary());
        buffs.Add(new System.DateTime(1970,1,1).ToBinary());
    }

    public User()
    {
        InitLists();
    }

    public User(string username, string email, string userID)
    {
        this.username = username;
        this.email = email;
        this.userID = userID;
        InitLists();
    }


    public User(string username, string email, string userID, int gold)
    {
        this.username = username;
        this.email = email;
        this.userID = userID;
        this.gold = gold;
        InitLists();
    }

    /// <summary>
    /// Call this whenever you scan a location
    /// </summary>
    /// <param name="location"></param>
    public void SetLocationTimestamp(Location location)
    {
        Debug.LogWarning("Set Location Timestamp " + location.locationName + " " + System.DateTime.Now);
        if (buffs[location.locationID] != 0)
        {
            if (System.DateTime.Now < System.DateTime.FromBinary(buffs[location.locationID]))
            {
                //Buff is still active. Don't update
                //Maybe visual feedback?
                return;
            }
            else
            {
                buffs[location.locationID] = System.DateTime.Now.AddSeconds(location.locationCooldown).ToBinary();
            }
        }
        else
        {
            buffs[location.locationID] = System.DateTime.Now.AddSeconds(location.locationCooldown).ToBinary();
        }

        //here!
        if(location.locationID == 0)
        {
            randomPowerUp = Random.Range(0, 15);
        }

        FirebaseManager.Instance.WriteNewUser(this);
    }
}

public static class CurrentUser
{
    public static User instance;
}

