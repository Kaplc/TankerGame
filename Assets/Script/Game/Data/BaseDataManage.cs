using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDataManage
{
    private static BaseDataManage _instance = new BaseDataManage();
    public static BaseDataManage Instance => _instance;

    public MusicData musicData;
    
    private BaseDataManage()
    {
        musicData = PlayerPrefsManager.Instance.Load(typeof(MusicData), "Music") as MusicData;
        
        if (musicData.firstStartUp == true)
        {
            musicData.firstStartUp = false;
            musicData.musicValue = 70f;
            musicData.soundValue = 70f;
            musicData.musicOpen = true;
            musicData.soundOpen = true;
            PlayerPrefsManager.Instance.Save(musicData, "Music");
        }
        
    }

    public void SettingMusicOpen(bool openOrClose)
    {
        musicData.musicOpen = openOrClose;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }
    public void SettingSoundOpen(bool openOrClose)
    {
        musicData.soundOpen = openOrClose;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }
    public void SettingMusicValue(float value)
    {
        musicData.musicValue= value;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }
    public void SettingSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsManager.Instance.Save(musicData, "Music");
    }
}