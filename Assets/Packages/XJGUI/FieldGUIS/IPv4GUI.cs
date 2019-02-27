using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IPv4GUI : FieldGUIElement<string>
    {
        #region Constructor

        public IPv4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.IPv4GUI()
            {
                Title = base.GUIInfo.Title,
            };
        }

        #endregion Constructor
    }
}