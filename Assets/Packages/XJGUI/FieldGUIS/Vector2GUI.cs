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
            base.gui = new XJGUI.Vector2GUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthValue : (float)guiInfo.FieldWidth,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueVector2 : (Vector2)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueVector2 : (Vector2)guiInfo.MaxValue,

                Decimals = guiInfo.Decimals == null ?
                           XJGUILayout.DefaultDecimals : (int)guiInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}