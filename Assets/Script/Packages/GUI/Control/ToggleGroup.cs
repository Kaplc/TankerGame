using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup : MonoBehaviour
{
    public Toggle[] toggles;
    
    Toggle oldIsTrueToggle = null; // 记录上一次为true的toggle
    
    private void Start()
    {
        if (toggles.Length == 0)
            return;

        for (int i = 0; i < toggles.Length; i++)
        {
            Toggle currToggle = toggles[i];
            
            currToggle.changeValue += (value) =>
            {
                // 传进来是true时改变另外的toggle
                if (value)
                {
                    for (int j = 0; j < toggles.Length; j++)
                    {
                        if (toggles[j] != currToggle) // 除去自身
                        {
                            toggles[j].isSel = false;
                        }
                    }

                    oldIsTrueToggle = currToggle; // 刷新上一次为true的toggle
                }
                else
                {
                    if (oldIsTrueToggle == currToggle) // 判断上一次为ture的是不是自己
                    {
                        currToggle.isSel = true; // 强行改成true
                    }
                }
                
                
            };
        }
    }
}
