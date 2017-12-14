using System;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumGUI<T> : FieldGUIComponent<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.EnumGUI<T>()
            {
                Value = (T)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        protected override int CheckUpdate(T value1, T value2)
        {
            return value1.CompareTo(value2) == 0 ? -1 : 0;
        }

        #endregion Method
    }
}