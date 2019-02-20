using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class StringGUI : FieldGUIElement<string>
    {
        #region Constructor

        public StringGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.StringGUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthString : (float)guiInfo.FieldWidth,
            };
        }

        #endregion Constructor
    }
}