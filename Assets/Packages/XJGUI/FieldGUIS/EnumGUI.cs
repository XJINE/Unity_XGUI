using System;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumGUI<T> : FieldGUIElement<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumGUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.EnumGUI<T>()
            {
                Title = base.GUIInfo.Title,
            };
        }

        #endregion Constructor
    }
}