using System;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumGUI<T> : FieldGUIComponent<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.EnumGUI<T>()
            {
                Value     = (T)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            this.gui.Value = (T)Enum.Parse(typeof(T), value);
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = this.gui.Value.ToString();
        }

        #endregion Method
    }
}