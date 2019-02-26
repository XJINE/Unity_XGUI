using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIElement<T> : FieldGUIBase
    {
        #region Field

        protected Element<T> gui;

        #endregion Field

        #region Constructor

        public FieldGUIElement(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void SetValueToInstance()
        {
            base.FieldInfo.SetValue(base.Data, this.gui.Value);
        }

        protected override void GetValueFromInstance()
        {
            this.gui.Value = (T)base.FieldInfo.GetValue(base.Data);
        }

        protected override void ShowGUI()
        {
            this.gui.Show();
        }

        #endregion Method
    }
}