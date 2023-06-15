using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    private static T _instance;
    public static T Instance => _instance;

    private void Awake()
    {
        // 实例化子类单例
        _instance = this as T;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Hide()
    {
        gameObject.SetActive(false);
        
    }
}