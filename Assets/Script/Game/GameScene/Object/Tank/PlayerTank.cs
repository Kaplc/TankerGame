using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

public class PlayerTank : BaseTank
{
    public int waponSpeed;
    public Texture quasiStar;
    
    // Update is called once per frame
    void Update()
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
            quasiStar.GUIPos.OffSetPos.y--;
            weapon.transform.Rotate(Vector3.right * (Time.deltaTime * waponSpeed));
        }
        if (Input.GetKey(KeyCode.E))
        {
            quasiStar.GUIPos.OffSetPos.y++;
            weapon.transform.Rotate(-Vector3.right * (Time.deltaTime * waponSpeed));
        }
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