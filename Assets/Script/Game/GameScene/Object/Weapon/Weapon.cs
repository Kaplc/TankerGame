using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public BaseTank father; // 安装该武器的对象
    public Transform[] firePos;

    public void SetFatherTank(BaseTank tank)
    {
        father = tank;
    }

    public void Fire()
    {
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