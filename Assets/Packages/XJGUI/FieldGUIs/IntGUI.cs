using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntGUI : FieldGUIElement<int>
    {
        #region Constructor

        public IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (int)guiInfo.MinValue : XJGUILayout.DefaultMinValueInt,
                MaxValue   = guiInfo.MaxValueIsSet ? (int)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueInt,
            };
        }

        #endregion Constructor
    }
}