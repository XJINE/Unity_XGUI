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
            Matrix4x4 minValue = guiInfo.MinValueIsSet ? new Matrix4x4()
            {
                m00 = guiInfo.MinValue, m10 = guiInfo.MinValue, m20 = guiInfo.MinValue, m30 = guiInfo.MinValue,
                m01 = guiInfo.MinValue, m11 = guiInfo.MinValue, m21 = guiInfo.MinValue, m31 = guiInfo.MinValue,
                m02 = guiInfo.MinValue, m12 = guiInfo.MinValue, m22 = guiInfo.MinValue, m32 = guiInfo.MinValue,
                m03 = guiInfo.MinValue, m13 = guiInfo.MinValue, m23 = guiInfo.MinValue, m33 = guiInfo.MinValue,
            } : XJGUILayout.DefaultMinValueMatrix4x4;

            Matrix4x4 maxValue = guiInfo.MaxValueIsSet ? new Matrix4x4()
            {
                m00 = guiInfo.MaxValue, m10 = guiInfo.MaxValue, m20 = guiInfo.MaxValue, m30 = guiInfo.MaxValue,
                m01 = guiInfo.MaxValue, m11 = guiInfo.MaxValue, m21 = guiInfo.MaxValue, m31 = guiInfo.MaxValue,
                m02 = guiInfo.MaxValue, m12 = guiInfo.MaxValue, m22 = guiInfo.MaxValue, m32 = guiInfo.MaxValue,
                m03 = guiInfo.MaxValue, m13 = guiInfo.MaxValue, m23 = guiInfo.MaxValue, m33 = guiInfo.MaxValue,
            } : XJGUILayout.DefaultMaxValueMatrix4x4;

            base.GUI = new XJGUI.Matrix4x4GUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = minValue,
                MaxValue   = maxValue,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}