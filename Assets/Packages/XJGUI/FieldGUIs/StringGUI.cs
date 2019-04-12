using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class StringGUI : FieldGUIElement<string>
    {
        #region Constructor

        public StringGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.StringGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthString,
            };
        }

        #endregion Constructor
    }
}