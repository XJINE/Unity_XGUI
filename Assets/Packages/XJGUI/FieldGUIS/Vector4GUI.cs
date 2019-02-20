using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector4GUI : FieldGUIElement<Vector4>
    {
        #region Constructor

        public Vector4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector4GUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthValue : (float)guiInfo.FieldWidth,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueVector4 : (Vector4)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueVector4 : (Vector4)guiInfo.MaxValue,

                Decimals = guiInfo.Decimals == null ?
                           XJGUILayout.DefaultDecimals : (int)guiInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}