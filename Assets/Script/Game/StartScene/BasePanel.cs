using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    private T _instance;
    public T Instance => _instance;

    private void Awake()
    {
        _instance = this as T;
    }
}