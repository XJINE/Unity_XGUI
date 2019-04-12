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
            base.GUI = new XJGUI.Vector3IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? new Vector3Int((int)guiInfo.MinValue, (int)guiInfo.MinValue, (int)guiInfo.MinValue) : XJGUILayout.DefaultMinValueVector3Int,
                MaxValue   = guiInfo.MaxValueIsSet ? new Vector3Int((int)guiInfo.MaxValue, (int)guiInfo.MaxValue, (int)guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueVector3Int,
            };
        }

        #endregion Constructor
    }
}