using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIComponent<T> : FieldGUIComponentBase<T>
    {
        #region Constructor

        public FieldGUIComponent(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void Load()
        {
            base.Load();
            this.previousValue = this.gui.Value;
        }

        protected override void ShowGUI()
        {
            T currentValue = this.gui.Show();

            base.updated = GetValueIsUpdated(currentValue, previousValue);

            this.previousValue = currentValue;
        }

        protected override bool GetValueIsUpdated(T value1, T value2)
        {
            return !value1.Equals(value2);
        }

        #endregion Method
    }
}