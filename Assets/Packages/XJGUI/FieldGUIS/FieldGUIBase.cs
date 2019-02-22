using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Property

        protected object       Data      { get; private set; }
        protected FieldInfo    FieldInfo { get; private set; }
        protected FieldGUIInfoAttribute GUIInfo   { get; private set; }

        public bool Unsupported { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIBase(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
        {
            this.Data      = data;
            this.FieldInfo = fieldInfo;
            this.GUIInfo   = guiInfo;
        }

        #endregion Constrcutor

        #region Method

        public void Show()
        {
            Load();
            ShowGUI();
            Save();
        }

        protected abstract void ShowGUI();

        protected abstract void Save();

        protected abstract void Load();

        #endregion Method
    }
}