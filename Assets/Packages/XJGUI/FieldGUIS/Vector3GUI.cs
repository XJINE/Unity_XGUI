using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3GUI : FieldGUIElement<Vector3>
    {
        #region Constructor

        public Vector3GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector3GUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthValue : (float)guiInfo.FieldWidth,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueVector3 : (Vector3)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueVector3 : (Vector3)guiInfo.MaxValue,

                Decimals = guiInfo.Decimals == null ?
                           XJGUILayout.DefaultDecimals : (int)guiInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}