using System;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumGUI<T> : FieldGUIElement<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.GUI = new XJGUI.EnumGUI<T>()
            {
                Title = base.GUIInfo.Title,
            };
        }

        #endregion Constructor
    }
}