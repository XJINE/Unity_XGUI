using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIElement<T> : FieldGUIBase
    {
        #region Property

        public virtual Element<T> GUI { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIElement(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void SetValueToInstance()
        {
            base.FieldInfo.SetValue(base.Data, this.GUI.Value);
        }

        protected override void GetValueFromInstance()
        {
            this.GUI.Value = (T)base.FieldInfo.GetValue(base.Data);
        }

        protected override void ShowGUI()
        {
            this.GUI.Show();
        }

        #endregion Method
    }
}