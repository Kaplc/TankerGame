using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // 单例 
    private static BGM _instance;
    public static BGM Instance => _instance;
    public AudioSource audioSource;

    private void Awake()
    {
        _instance = this;
        // 初始化数据
        audioSource.volume = BaseDataManage.Instance.musicData.musicValue;
        OpenMusic(BaseDataManage.Instance.musicData.musicOpen);
        // 循环播放
        
    }

    private void Update()
    {
        // 循环播放
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    public void ChangeMusicVolume(float value) => audioSource.volume = value;

    // 静音
    public void OpenMusic(bool open) => audioSource.mute = !open;
}