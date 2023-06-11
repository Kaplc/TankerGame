using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toggle : BaseControl
{
    public bool isSel;

    public event UnityAction<bool> changeValue; // 有一个bool的参数
    private bool isOldSel;

    protected override void StyleOnShow()
    {
        isSel = GUI.Toggle(GUIPos.Position, isSel, Content, Style);

        if (isOldSel != isSel) // 勾选状态发生改变才进行后续步骤
        {
            changeValue?.Invoke(isSel); // isSel传参给委托中的每个函数,通知所有订阅changeValue事件的方法，isSel的值已经发生了变化，以便它们可以采取相应的操作或逻辑
            isOldSel = isSel;
        }
    }

    protected override void StyleOffShow()
    {
        isSel = GUI.Toggle(GUIPos.Position, isSel, Content);
        if (isOldSel != isSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }
}