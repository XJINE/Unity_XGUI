using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3GUI : FieldGUIElement<Vector3>
    {
        #region Constructor

        public Vector3GUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector3GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (Vector3)guiInfo.MinValue : XJGUILayout.DefaultMinValueVector3,
                MaxValue   = guiInfo.MaxValueIsSet ? (Vector3)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueVector3,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}