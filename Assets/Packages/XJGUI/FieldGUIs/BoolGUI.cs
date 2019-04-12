using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class BoolGUI : FieldGUIElement<bool>
    {
        #region Constructor

        public BoolGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.BoolGUI()
            {
                Title = guiInfo.Title,
            };
        }

        #endregion Constructor
    }
}