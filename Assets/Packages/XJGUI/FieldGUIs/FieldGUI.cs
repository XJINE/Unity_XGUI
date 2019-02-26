using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FieldGUI : FieldGUIElement<object>
    {
        #region Constructor

        public FieldGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.FieldGUI();
        }

        #endregion Constructor
    }
}