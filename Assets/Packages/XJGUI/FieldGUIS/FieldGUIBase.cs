using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Property

        // NOTE:
        // Data must be able to set from inheritance,
        // because it gets struct type in sometimes.

        public object       Data      { get; protected set; }
        public FieldInfo    FieldInfo { get; private   set; }
        public FieldGUIInfo GUIInfo   { get; private   set; }

        public bool Unsupported { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIBase(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            this.Data      = data;
            this.FieldInfo = fieldInfo;
            this.GUIInfo   = guiInfo;
        }

        #endregion Constrcutor

        #region Method

        public void Show()
        {
            GetValueFromInstance();
            ShowGUI();
            SetValueToInstance();
        }

        protected abstract void ShowGUI();

        protected abstract void SetValueToInstance();

        protected abstract void GetValueFromInstance();

        #endregion Method
    }
}