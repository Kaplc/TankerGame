using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject father; // 安装对象
    public GameObject[] firePos;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTank(BaseTank tank)
    {
        father = tank.gameObject;
    }
    public void Fire()
    {
        for (int i = 0; i < firePos.Length; i++)
        {
            // 创建子弹
            GameObject bullet = Instantiate(bulletPrefab, firePos[i].transform.position,
                firePos[i].transform.rotation);
            // 设置子弹父对象
            bullet.GetComponent<Bullet>().father = father;
        }
    }

    
}
