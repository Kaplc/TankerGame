using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    public int atk;
    public int def;
    public int hp;
    public int maxHp;

    public int speed = 10;
    public float bodyRotationSpeed = 10;
    public float headRotationSpeed = 10;

    public GameObject head; 
    public GameObject deadEff; // 死亡特效
    public Weapon weapon; // 武器
    

    public abstract void Move();
    public abstract void Shoot();

    private void Start()
    {
        SetWeapon(weapon);
    }

    public void SetWeapon(Weapon weaponObj)
    {
        weapon = weaponObj;
    }

    public virtual void Wound(BaseTank otherTank)
    {
        hp -= otherTank.atk - def;

        if (hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

    public virtual void Dead()
    {
        // 实例化死亡特效对象
        GameObject deadEff = Instantiate(this.deadEff, transform.position, transform.rotation);

        // 控制特效音效
        AudioSource audioSource = deadEff.GetComponent<AudioSource>();
        audioSource.volume = BaseDataManage.Instance.musicData.musicValue;
        audioSource.mute = !BaseDataManage.Instance.musicData.soundOpen;
    }
}