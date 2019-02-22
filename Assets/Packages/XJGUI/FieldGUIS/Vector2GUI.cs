using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2GUI : FieldGUIElement<Vector2>
    {
        #region Constructor

        public Vector2GUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector2GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (Vector2)guiInfo.MinValue : XJGUILayout.DefaultMinValueVector2,
                MaxValue   = guiInfo.MaxValueIsSet ? (Vector2)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueVector2,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}