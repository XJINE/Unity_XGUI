using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Matrix4x4GUI : FieldGUIElement<Matrix4x4>
    {
        #region Constructor

        public Matrix4x4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.Matrix4x4GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (Matrix4x4)guiInfo.MinValue : XJGUILayout.DefaultMinValueMatrix4x4,
                MaxValue   = guiInfo.MaxValueIsSet ? (Matrix4x4)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueMatrix4x4,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}