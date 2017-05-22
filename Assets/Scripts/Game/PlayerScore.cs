using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : IComparer<PlayerScore> {

    public string playerName;
    public int score;

    public static int localScore;

    public int Compare(PlayerScore x, PlayerScore y)
    {
        return this.score.CompareTo(y.score);
    }

}
