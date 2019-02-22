using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class StringGUI : FieldGUIElement<string>
    {
        #region Constructor

        public StringGUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.StringGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthString,
            };
        }

        #endregion Constructor
    }
}