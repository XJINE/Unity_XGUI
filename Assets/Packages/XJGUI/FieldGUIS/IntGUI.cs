using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntGUI : FieldGUIElement<int>
    {
        #region Constructor

        public IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.IntGUI()
            {
                Title    = base.GUIInfo.Title,
                MinValue = (int)base.GUIInfo.MinValue,
                MaxValue = (int)base.GUIInfo.MaxValue,
            };
        }

        #endregion Constructor
    }
}