using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo
{
    public string name;
    public int score;
    public int time;

    public RankInfo()
    {
    }

    public RankInfo(string name, int score, int time)
    {
        this.time = time;
        this.name = name;
        this.score = score;
    }
}

public class RankInfos
{
    public List<RankInfo> rankList;
}