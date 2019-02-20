using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatGUI : FieldGUIElement<float>
    {
        #region Constructor

        public FloatGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.FloatGUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthValue : (float)guiInfo.FieldWidth,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueFloat : (float)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueFloat : (float)guiInfo.MaxValue,

                Decimals = guiInfo.Decimals == null ?
                           XJGUILayout.DefaultDecimals : (int)guiInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}