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
            base.GUI = new XJGUI.Vector3GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? new Vector3(guiInfo.MinValue, guiInfo.MinValue, guiInfo.MinValue) : XJGUILayout.DefaultMinValueVector3,
                MaxValue   = guiInfo.MaxValueIsSet ? new Vector3(guiInfo.MaxValue, guiInfo.MaxValue, guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueVector3,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}