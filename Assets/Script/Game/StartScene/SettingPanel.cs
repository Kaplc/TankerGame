﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public Button btnClose;
    public Toggle togMusic;
    public Toggle togSound;
    public Slider sldMusic;
    public Slider sldSound;

    // Start is called before the first frame update
    void Start()
    {
        // 添加改变值时的后续要执行的函数
        togMusic.changeValue += (value) => BaseDataManage.Instance.SettingMusicOpen(value); // 存盘
        togSound.changeValue += (value) => BaseDataManage.Instance.SettingSoundOpen(value);
        sldMusic.settingValue += (value) => BaseDataManage.Instance.SettingMusicValue(value);
        sldSound.settingValue += (value) => BaseDataManage.Instance.SettingSoundValue(value);
        
        btnClose.ClickEvent += () =>
        {
            StartPanel.Instance.Show();
            this.Hide();
        };
        togMusic.changeValue += (value) => { };
        togSound.changeValue += (value) => { };
        sldMusic.settingValue += (value) => { };
        sldSound.settingValue += (value) => { };
        this.Hide(); // 设置面板先隐藏自己
    }

    public override void Hide()
    {
        base.Hide();
        UpdateInfos(); 
    }

    private void UpdateInfos()
    {
        // 读取数据并覆写
        MusicData musicData = BaseDataManage.Instance.musicData;
        togMusic.isSel = musicData.musicOpen;
        togSound.isSel = musicData.soundOpen;
        sldMusic.value = musicData.musicValue;
        sldSound.value = musicData.soundValue;
    }
}