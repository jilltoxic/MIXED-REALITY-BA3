using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScore
{
    public int RubyRiderScore;
    public int GoldenCircleScore;
    public TeamScore() { RubyRiderScore = 0; GoldenCircleScore = 0; }
}

public static class CurrentTeamScore
{
    static TeamScore _instance;
    public static TeamScore instance
    {
        get { if (_instance == null) _instance = new TeamScore();  return _instance; }
        set { _instance = value; }
    }
}
