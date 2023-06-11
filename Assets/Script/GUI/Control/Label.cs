using UnityEngine;

namespace Control
{
    public class Label: BaseControl
    {
        protected override void StyleOnShow()
        {
            GUI.Label(GUIPos.Position, Content, Style);
        }

        protected override void StyleOffShow()
        {
            GUI.Label(GUIPos.Position, Content);
        }
    }
}