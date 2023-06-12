using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_SliderType
{
    Horizontal,
    Vertical
}

public class Slider : BaseControl
{
    private float _oldValue;
    public float max = 100;
    public float min = 0;
    public float value = 0;

    public E_SliderType type;
    public GUIStyle thumbStyle;
    public UnityAction<float> settingValue;

    protected override void StyleOnShow()
    {
        switch (type)
        {
            case E_SliderType.Horizontal:
                value = GUI.HorizontalSlider(GUIPos.Position, value, min, max, Style, thumbStyle);
                break;
            case E_SliderType.Vertical:
                value = GUI.VerticalSlider(GUIPos.Position, value, max, min, Style, thumbStyle);
                break;
        }

        if (_oldValue != value)
        {
            settingValue?.Invoke(value);
            _oldValue = value;
        }
    }

    protected override void StyleOffShow()
    {
        switch (type)
        {
            case E_SliderType.Horizontal:
                value = GUI.HorizontalSlider(GUIPos.Position, value, min, max);
                break;
            case E_SliderType.Vertical:
                value = GUI.VerticalSlider(GUIPos.Position, value, max, min);
                break;
        }

        if (_oldValue != value)
        {
            settingValue?.Invoke(value);
            _oldValue = value;
        }
    }
}