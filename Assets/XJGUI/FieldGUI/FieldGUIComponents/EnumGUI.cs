using System;
using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class EnumGUI<T> : FieldGUIComponent<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumGUI(System.Object data, FieldInfo info, FieldGUIInfo attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.EnumGUI<T>()
            {
                Value = (T)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
            };
        }

        #endregion Method
    }
}