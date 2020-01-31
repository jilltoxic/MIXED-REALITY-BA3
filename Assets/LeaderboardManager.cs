using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public class LeaderboardEntryData
    {
        public LeaderboardEntryData(string n, int s)
        {
            name = n;
            score = s;
        }

        public string name;
        public int score;
    }

    List<LeaderboardEntryData> teamRubyRiders;
    List<LeaderboardEntryData> teamGoldenCircle;

    public static bool dirtyFlag;
    public static DataSnapshot data;

    public Transform parentRubyRiders, parentGoldenCircle;
    public GameObject prefabRubyRiders, prefabGoldenCircle;

    private void Start()
    {
        FirebaseManager.Instance.GetTopPlayers();
    }

    private void Update()
    {
        if (dirtyFlag)
        {
            AdaptData();
            dirtyFlag = false;
        }
    }

    void AdaptData()
    {
        teamRubyRiders = new List<LeaderboardEntryData>();
        teamGoldenCircle = new List<LeaderboardEntryData>();

        foreach (DataSnapshot leader in data.Children)
        {
            if (leader.Child("team").Value.ToString() == "0")
                teamRubyRiders.Add(new LeaderboardEntryData(leader.Child("username").Value.ToString(), int.Parse(leader.Child("userScore").Value.ToString())));
            else
                teamGoldenCircle.Add(new LeaderboardEntryData(leader.Child("username").Value.ToString(), int.Parse(leader.Child("userScore").Value.ToString())));
        }

        CreateLeaderboards();
    }

    void CreateLeaderboards()
    {
        foreach (Transform child in parentGoldenCircle)
            Destroy(child.gameObject);

        foreach (Transform child in parentRubyRiders)
            Destroy(child.gameObject);

        for (int i = teamGoldenCircle.Count - 1; i >= 0; i--)
        {
            LeaderboardEntry newEntry = Instantiate(prefabGoldenCircle, parentGoldenCircle).GetComponent<LeaderboardEntry>();
            newEntry.SetField(teamGoldenCircle[i].name, teamGoldenCircle[i].score.ToString());
        }

        for (int i = teamRubyRiders.Count - 1; i >= 0; i--)
        {
            LeaderboardEntry newEntry = Instantiate(prefabRubyRiders, parentRubyRiders).GetComponent<LeaderboardEntry>();
            newEntry.SetField(teamRubyRiders[i].name, teamRubyRiders[i].score.ToString());
        }
    }
}
