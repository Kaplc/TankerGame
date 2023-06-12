using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : BaseControl
{
    public event UnityAction ClickEvent;

    protected override void StyleOnShow()
    {
        if (GUI.Button(GUIPos.Position, Content, Style))
        {
            ClickEvent?.Invoke();
        }
    }

    protected override void StyleOffShow()
    {
        if (GUI.Button(GUIPos.Position, Content))
        {
            ClickEvent?.Invoke();
        }
    }
}