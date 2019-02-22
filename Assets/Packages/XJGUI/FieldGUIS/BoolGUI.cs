using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class BoolGUI : FieldGUIElement<bool>
    {
        #region Constructor

        public BoolGUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.BoolGUI()
            {
                Title = guiInfo.Title,
            };
        }

        #endregion Constructor
    }
}