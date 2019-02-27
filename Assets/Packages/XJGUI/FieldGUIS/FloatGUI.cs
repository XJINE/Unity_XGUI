using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatGUI : FieldGUIElement<float>
    {
        #region Constructor

        public FloatGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.FloatGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (float)guiInfo.MinValue : XJGUILayout.DefaultMinValueFloat,
                MaxValue   = guiInfo.MaxValueIsSet ? (float)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueFloat,
                Decimals   = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}