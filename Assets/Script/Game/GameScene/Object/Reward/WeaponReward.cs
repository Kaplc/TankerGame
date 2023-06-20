using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponReward : BaseReward
{
    public List<Weapon> weapons;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Round();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            // 随机获取
            int weaponIndex = Random.Range(0, weapons.Count - 1);
            PlayerTank player = other.GetComponent<PlayerTank>();
            player.InstallWeapon(weapons[weaponIndex]);
        }
    }
}