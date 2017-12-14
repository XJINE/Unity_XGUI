using System.Collections;
using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIComponent<T> : FieldGUIBase
    {
        #region Field

        protected ElementGUI<T> gui;

        protected T previousValue;

        #endregion Field

        #region Constructor

        public FieldGUIComponent(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
            base.IsIListType = data is IList;
            base.Type = base.IsIListType ? typeof(T).GetGenericTypeDefinition() : typeof(T);
        }

        #endregion Constructor

        #region Method

        protected override void Save()
        {
            base.fieldInfo.SetValue(base.data, this.gui.Value);
        }

        protected override void Load()
        {
            this.gui.Value = (T)base.fieldInfo.GetValue(base.data);
        }

        protected override void ShowGUI()
        {
            T currentValue = this.gui.Show();

            base.UpdateIndex = CheckUpdate(currentValue, previousValue);

            this.previousValue = currentValue;
        }

        public override void SetValue(object value, int index = -1)
        {
            this.gui.Value = (T)value;
        }

        public override object GetValue()
        {
            return this.gui.Value;
        }

        // CAUTION:
        // Make this inheritance class & implement common "CheckUpdate" is bad way.
        // Instance of "T" cannot compare by "==" & Vector2,3,4… can't compare by "IComparable.CompareTo".

        protected abstract int CheckUpdate(T value1, T value2);

        #endregion Method
    }
}