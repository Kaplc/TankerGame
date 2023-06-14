using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public Button btnClose;
    
    public List<Label> nameList = new List<Label>();
    public List<Label> scoreList = new List<Label>();
    public List<Label> timeList = new List<Label>();

    private void Start()
    {
        // 添加所有子对象到List
        for (int i = 1; i < 11; i++)
        {
            // Name/ 加'\'可以指定哪个对象的子对象
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

    private void UpdateInfos()
    {
        // 读取数据并更新到ui面板
        RankInfos rankInfos = BaseDataManage.Instance.rankInfos;
        List<RankInfo> rankList = rankInfos.rankList;
        for (int i = 0; i < rankList.Count; i++)
        {
            nameList[i].Content.text  = rankList[i].name;
            scoreList[i].Content.text = rankList[i].score.ToString();
            
            // 计算分钟
            timeList[i].Content.text = (rankList[i].time / 60) + "分" + (rankList[i].time % 60) + "秒";
        }
    }
}