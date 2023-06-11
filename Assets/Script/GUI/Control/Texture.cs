using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : BaseControl
{
    public ScaleMode scaleMode;

    protected override void StyleOnShow()
    {
        GUI.DrawTexture(GUIPos.Position, Content.image, scaleMode);
    }

    protected override void StyleOffShow()
    {
        GUI.DrawTexture(GUIPos.Position, Content.image, scaleMode);
    }
}
