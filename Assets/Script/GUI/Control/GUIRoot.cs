using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GUIRoot : MonoBehaviour
{
    private BaseControl[] _controls;

    // Start is called before the first frame update
    void Start()
    {
        // 获取子对象的脚本
        _controls = this.GetComponentsInChildren<BaseControl>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        // 运行时不获取子对象的脚本
        if (!Application.isPlaying)
        {
            _controls = this.GetComponentsInChildren<BaseControl>();
        }

        for (int i = 0; i < _controls.Length; i++)
        {
            _controls[i].Draw(); // 顺序调用控件绘制方法
        }
    }
}