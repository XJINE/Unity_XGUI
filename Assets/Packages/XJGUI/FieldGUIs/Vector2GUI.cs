using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2GUI : FieldGUIElement<Vector2>
    {
        #region Constructor

        public Vector2GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.Vector2GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? new Vector2(guiInfo.MinValue, guiInfo.MinValue) : XJGUILayout.DefaultMinValueVector2,
                MaxValue   = guiInfo.MaxValueIsSet ? new Vector2(guiInfo.MaxValue, guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueVector2,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}