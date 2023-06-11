using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_Off
{
   On,
   Off
}

public abstract class BaseControl: MonoBehaviour
{
   // 位置
   public BaseRect GUIPos;
   // 内容
   public GUIContent Content = new GUIContent();
   // 自定义样式开关
   public E_Style_Off StyleOnOrOff = E_Style_Off.Off;
   public GUIStyle Style;
   
   public void Draw()
   {
      switch (StyleOnOrOff)
      {
         case E_Style_Off.On:
            StyleOnShow();
            break;
         case E_Style_Off.Off:
            StyleOffShow();
            break;
      }
   }

   protected abstract void StyleOnShow();
   
   protected abstract void StyleOffShow();
   
}
