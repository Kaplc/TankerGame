using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_RewardType
{
    Atk,
    Def,
    MaxHp,
    Hp,
    Speed
}

public class AttributeReward : BaseReward
{
    public E_RewardType type;

    public int value;

    // Update is called once per frame
    void Update()
    {
        Round();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            PlayerTank playerTank = other.GetComponent<PlayerTank>();
            switch (type)
            {
                case E_RewardType.Atk:
                    playerTank.atk += value;
                    break;
                case E_RewardType.Def:
                    playerTank.def += value;
                    break;
                case E_RewardType.Speed:
                    playerTank.speed += value;
                    playerTank.bodyRotationSpeed += value;
                    break;
                case E_RewardType.MaxHp:
                    playerTank.hp += value;
                    playerTank.maxHp += value;
                    // 更新血条
                    GamePanel.Instance.UpdateHp(playerTank.maxHp, playerTank.hp);
                    break;
                case E_RewardType.Hp:
                    playerTank.hp += value;
                    if (playerTank.hp >= playerTank.maxHp)
                    {
                        playerTank.hp = playerTank.maxHp;
                    }
                    GamePanel.Instance.UpdateHp(playerTank.maxHp, playerTank.hp);
                    break;
            }
        }
    }
}
