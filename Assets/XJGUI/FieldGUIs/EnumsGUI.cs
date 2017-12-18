using System;
using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumsGUI<T> : FieldGUIComponents<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.EnumsGUI<T>()
            {
                Value     = (IList<T>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            ((ElementsGUI<T>)base.gui).SetValue(index, (T)Enum.Parse(typeof(T), value));
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].ToString();
        }

        #endregion Method
    }
}