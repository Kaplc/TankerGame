using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public Button btnClose;
    
    public List<Label> rankList = new List<Label>();
    public List<Label> nameList = new List<Label>();
    public List<Label> scoreList = new List<Label>();
    public List<Label> timeList = new List<Label>();

    private void Start()
    {
        // 添加所有子对象到List
        for (int i = 1; i < 11; i++)
        {
            // Rank/ 加'\'可以指定哪个对象的子对象
            rankList.Add(transform.Find("Rank/RankLabel" + i).GetComponent<Label>());
            nameList.Add(transform.Find("Name/NameLabel" + i).GetComponent<Label>());
            scoreList.Add(transform.Find("Score/ScoreLabel" + i).GetComponent<Label>());
            timeList.Add(transform.Find("Time/TimeLabel" + i).GetComponent<Label>());
        }

        btnClose.ClickEvent += () =>
        {
            StartPanel.Instance.Show();
            Hide();
        };
        
        Hide();
    }

    public override void Hide()
    {
        base.Hide();
        UpdateInfos();
    }

    public void UpdateInfos()
    {
    }
}