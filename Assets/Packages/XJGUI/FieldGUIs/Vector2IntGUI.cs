using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2IntGUI : FieldGUIElement<Vector2Int>
    {
        #region Constructor

        public Vector2IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector2IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (Vector2Int)guiInfo.MinValue : XJGUILayout.DefaultMinValueVector2Int,
                MaxValue   = guiInfo.MaxValueIsSet ? (Vector2Int)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueVector2Int,
            };
        }

        #endregion Constructor
    }
}