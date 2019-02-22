using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3IntGUI : FieldGUIElement<Vector3Int>
    {
        #region Constructor

        public Vector3IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector3IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (Vector3Int)guiInfo.MinValue : XJGUILayout.DefaultMinValueVector3Int,
                MaxValue   = guiInfo.MaxValueIsSet ? (Vector3Int)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueVector3Int,
            };
        }

        #endregion Constructor
    }
}