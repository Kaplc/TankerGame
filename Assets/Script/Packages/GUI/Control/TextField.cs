using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TextField : BaseControl
{
    private string _oldStr = "";
    public int maxLength = 100;
    public UnityAction<string> ac;

    protected override void StyleOnShow()
    {
        Content.text = GUI.TextField(GUIPos.Position, Content.text, maxLength, Style);
        if (Content.text != _oldStr)
        {
            ac += (value) =>
            {
                ac?.Invoke(value);
                _oldStr = Content.text;
            };
        }
    }

    protected override void StyleOffShow()
    {
        Content.text = GUI.TextField(GUIPos.Position, Content.text, maxLength);
        if (Content.text != _oldStr)
        {
            ac += (value) =>
            {
                ac?.Invoke(value);
                _oldStr = Content.text;
            };
        }
    }
}