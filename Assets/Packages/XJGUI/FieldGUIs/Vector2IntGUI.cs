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
            base.GUI = new XJGUI.Vector2IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? new Vector2Int((int)guiInfo.MinValue, (int)guiInfo.MinValue) : XJGUILayout.DefaultMinValueVector2Int,
                MaxValue   = guiInfo.MaxValueIsSet ? new Vector2Int((int)guiInfo.MaxValue, (int)guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueVector2Int,
            };
        }

        #endregion Constructor
    }
}