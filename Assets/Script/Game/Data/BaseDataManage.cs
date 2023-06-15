using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDataManage
{
    private static BaseDataManage _instance = new BaseDataManage();
    public static BaseDataManage Instance => _instance;

    public MusicData musicData;
    public RankInfos rankInfos;

    private BaseDataManage()
    {
        // 读取数据初始化
        musicData = PlayerPrefsManager.Instance.Load(typeof(MusicData), "Music") as MusicData; 
        rankInfos = PlayerPrefsManager.Instance.Load(typeof(RankInfos), "Rank") as RankInfos;
        
        // 第一次启动游戏声音默认设置
        if (musicData.firstStartUp == true)
        {
            musicData.firstStartUp = false;
            musicData.musicValue = 0.7f;
            musicData.soundValue = 0.7f;
            musicData.musicOpen = true;
            musicData.soundOpen = true;
            PlayerPrefsManager.Instance.Save(musicData, "Music");
        }
    }

    #region 声音保存

    public void SettingMusicOpen(bool open)
    {
        musicData.musicOpen = open;
        BGM.Instance.OpenMusic(open); // 是否静音
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }

    public void SettingSoundOpen(bool open)
    {
        musicData.soundOpen = open;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }

    public void SettingMusicValue(float value)
    {
        musicData.musicValue = value;
        BGM.Instance.ChangeMusicVolume(value);
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }

    public void SettingSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }

    #endregion

    #region 排行榜保存

    public void AddRank(string name, int score, int time)
    {
        RankInfo newInfo = new RankInfo(name, score, time);
        rankInfos.rankList.Add(newInfo);
        // 按时间排序
        rankInfos.rankList.Sort((x, y) => x.time < y.time ? -1 : 1);
        
        // 去除第10条以后的数据
        if (rankInfos.rankList.Count > 10)
        {   
            // RemoveRange(开始索引, 移除数量);
            rankInfos.rankList.RemoveRange(10, rankInfos.rankList.Count - 10);
        }
        PlayerPrefsManager.Instance.Save(rankInfos, "Rank");
    }

    #endregion
}