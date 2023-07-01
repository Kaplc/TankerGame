using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName = "";
    public float cd = 0;
    private float currCd = 0;
    
    public GameObject bulletPrefab; // 子弹预设体
    
    public BaseTank father; // 安装该武器的对象

    public Transform[] firePos; // 炮口坐标
    
    private void Update()
    {
        if (currCd>=0)
        {
            currCd -= Time.deltaTime;
            GamePanel.Instance.lbCd.Content.text = Math.Round(currCd,2) + "s";
            return;
        }

        GamePanel.Instance.lbCd.Content.text = "";

    }

    public void SetFatherTank(BaseTank tank)
    {
    }

    public void Fire()
    {
        if (currCd >= 0) return;
        currCd = cd;

        for (int i = 0; i < firePos.Length; i++)
        {
            // 创建子弹
            GameObject bullet = Instantiate(bulletPrefab, firePos[i].position, firePos[i].rotation);
            // 发射音效
            AudioSource audioSource = bullet.GetComponent<AudioSource>();
            audioSource.volume = BaseDataManage.Instance.musicData.soundValue;
            audioSource.mute = !BaseDataManage.Instance.musicData.soundOpen;
            // 设置子弹发射对象
            Bullet bulletCpm = bullet.GetComponent<Bullet>();
            bulletCpm.SetFatherTank(father); // 
        }
    }
}