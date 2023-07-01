using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

public class PlayerTank : BaseTank
{
    public int waponSpeed;
    
    private Vector2 _quasiStarOriginalPos; // 准星原位置

    private void Start()
    {
        weapon = Instantiate(weapon, weaponMount, false); // 初始化武器
        _quasiStarOriginalPos = GamePanel.Instance.quasiStar.GUIPos.OffSetPos; // 记录准星原始位置
    }

    // Update is called once per frame
    public void Update()
    {
        Move();
        // 射击
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        // 炮管角度
        if (Input.GetKey(KeyCode.Q))
        {
            if (GamePanel.Instance.quasiStar.GUIPos.OffSetPos.y >=-68 && GamePanel.Instance.lbCd.GUIPos.OffSetPos.y >=-68)
            {
                GamePanel.Instance.quasiStar.GUIPos.OffSetPos.y--;
                GamePanel.Instance.lbCd.GUIPos.OffSetPos.y--;
            }

            if (weapon.gameObject.transform.rotation.x <= 0)
            {
                weapon.gameObject.transform.Rotate(Vector3.right * (Time.deltaTime * waponSpeed));
            }
            
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (GamePanel.Instance.quasiStar.GUIPos.OffSetPos.y <=100 && GamePanel.Instance.lbCd.GUIPos.OffSetPos.y <=100)
            {
                GamePanel.Instance.quasiStar.GUIPos.OffSetPos.y++;
                GamePanel.Instance.lbCd.GUIPos.OffSetPos.y++;
            }
            
            if (weapon.gameObject.transform.rotation.x >= -0.15)
            {
                weapon.gameObject.transform.Rotate(-Vector3.right * (Time.deltaTime * waponSpeed));
            }
        }
    }

    public void InstallWeapon(Weapon otherWeapon)
    {
        Destroy(this.weapon.gameObject);
        // 创建武器对象作为炮台的子对象
        this.weapon = Instantiate(otherWeapon, weaponMount, false); 
        //准星位置复原
        GamePanel.Instance.quasiStar.GUIPos.OffSetPos = _quasiStarOriginalPos;
        GamePanel.Instance.lbCd.GUIPos.OffSetPos = _quasiStarOriginalPos;
    }

    public override void Move()
    {
        // 前后
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * Time.deltaTime * speed));
        // 身体旋转
        transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * Time.deltaTime * bodyRotationSpeed));
        // 炮台旋转
        head.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * Time.deltaTime * headRotationSpeed));
    }

    public override void Shoot()
    {
        weapon.Fire();
    }

    public override void Dead()
    {
        base.Dead();
        Destroy(gameObject);
    }

    public override void Wound(BaseTank otherTank)
    {
        base.Wound(otherTank);
        // 更新面板血量
        GamePanel.Instance.UpdateHp(maxHp, hp);
    }
}