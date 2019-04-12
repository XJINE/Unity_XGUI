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
            base.GUI = new XJGUI.Vector4GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? new Vector4(guiInfo.MinValue, guiInfo.MinValue, guiInfo.MinValue, guiInfo.MinValue) : XJGUILayout.DefaultMinValueVector4,
                MaxValue   = guiInfo.MaxValueIsSet ? new Vector4(guiInfo.MaxValue, guiInfo.MaxValue, guiInfo.MaxValue, guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueVector4,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}