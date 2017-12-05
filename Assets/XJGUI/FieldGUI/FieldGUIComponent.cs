using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIComponent<T> : FieldGUIBase
    {
        #region Field

        protected ComponentBaseGUI<T> gui;

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
            base.info.SetValue(base.data, this.gui.Value);
        }

        protected override void Load()
        {
            this.gui.Value = (T)base.info.GetValue(base.data);
        }

        protected override void ShowGUI()
        {
            this.gui.Show();
        }

        #endregion Method
    }
}