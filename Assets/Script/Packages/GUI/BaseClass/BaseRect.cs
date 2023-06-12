using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

/// <summary>
/// 对齐类型
/// </summary>
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    LeftUp,
    LeftDown,
    RightUp,
    RightDown,
}

// 
[System.Serializable]
public class BaseRect
{
    // 内部最终偏移位置
    private Rect _pos = new Rect(0, 0, 100, 100);

    // 屏幕对齐方式
    public E_Alignment_Type ScreenAlignmentType = E_Alignment_Type.Center;

    // 控件对齐方式
    public E_Alignment_Type ControlCenterAlignmentType = E_Alignment_Type.Center;

    // 偏移位置
    public Vector2 OffSetPos;

    // 控件大小h,w
    public float Width = 100;
    public float Height = 50;

    public Rect Position
    {
        get
        {
            // 计算
            CalCenterPos();
            CalPos();
            // 返回
            _pos.width = Width;
            _pos.height = Height;
            return _pos;
        }
    }

    private Vector2 centerPos;

    private void CalCenterPos()
    {
        switch (ControlCenterAlignmentType)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -Width/2;
                centerPos.y = -Height;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -Width/2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = -Width;
                centerPos.y = -Height/2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = 0;
                centerPos.y = -Height/2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -Width/2;
                centerPos.y = -Height/2;
                break;
            case E_Alignment_Type.LeftUp:
                centerPos.x = -Width;
                centerPos.y = -Height;
                break;
            case E_Alignment_Type.LeftDown:
                centerPos.x = -Width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.RightUp:
                centerPos.x = 0;
                centerPos.y = -Height;
                break;
            case E_Alignment_Type.RightDown:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
        }
    }
    
    private void CalPos()
    {
        switch (ScreenAlignmentType)
        {
            case E_Alignment_Type.Up:
                // 屏幕偏移+控件偏移+自定义偏移
                _pos.x = Screen.width / 2 + centerPos.x + OffSetPos.x;
                _pos.y = 0 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.Down:
                _pos.x = Screen.width / 2 + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.Left:
                _pos.x = 0 + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height / 2 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.Right:
                _pos.x = Screen.width + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height / 2 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.Center:
                _pos.x = Screen.width / 2 + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height / 2 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.LeftUp:
                _pos.x = 0 + centerPos.x + OffSetPos.x;
                _pos.y = 0 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.LeftDown:
                _pos.x = 0 + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.RightUp:
                _pos.x = Screen.width + centerPos.x + OffSetPos.x;
                _pos.y = 0 + centerPos.y - OffSetPos.y;
                break;
            case E_Alignment_Type.RightDown:
                _pos.x = Screen.width + centerPos.x + OffSetPos.x;
                _pos.y = Screen.height + centerPos.y - OffSetPos.y;
                break;
        }
    }
}