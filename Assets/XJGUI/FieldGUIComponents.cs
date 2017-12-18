using System.Collections.Generic;
using System.Reflection;

namespace XJGUI
{
    // NOTE:
    // We cannot set a "where T: struct" because of the "string" allow null.

    // CAUTION:
    // FieldGUI(Components) does not support "Value" Count / Length changing when Sync.
    // Because we can not identify the operation is "add", "remove", "replace" or anyothers.
    // We can update all of the value when update the values counts.
    // However, do not so now. Maybe it occurs some problem.
    // Ex.If an array value is replaced and the Length is different from previous's,
    // there is no way to same update in client.

    public abstract class FieldGUIComponents<T> : FieldGUIComponentBase<IList<T>>
    {
        #region Constructor

        public FieldGUIComponents(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void Load()
        {
            base.Load();

            T[] previousValue = new T[this.gui.Value.Count];
            this.gui.Value.CopyTo(previousValue, 0);
            this.previousValue = previousValue;
        }

        protected override void ShowGUI()
        {
            this.gui.Show();

            base.updateIndex = CheckUpdateForSync(this.gui.Value, base.previousValue);

            T[] previousValue = new T[this.gui.Value.Count];

            this.gui.Value.CopyTo(previousValue, 0);

            base.previousValue = previousValue;
        }

        protected override int CheckUpdateForSync(IList<T> value1, IList<T> value2)
        {
            for (int i = 0; i < value1.Count; i++)
            {
                if (!value1[i].Equals(value2[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion Method
    }
}