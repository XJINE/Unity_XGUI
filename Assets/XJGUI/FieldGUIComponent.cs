using System;
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

        public FieldGUIComponent(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
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

            base.IsUpdate = !CheckSameValue(currentValue, previousValue);

            this.previousValue = currentValue;
        }

        public override void SetValue(object value)
        {
            this.gui.Value = (T)value;
        }

        protected abstract bool CheckSameValue(T value1, T value2);

        #endregion Method
    }
}