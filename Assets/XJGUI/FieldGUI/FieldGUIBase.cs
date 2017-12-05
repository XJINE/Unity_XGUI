using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase<T>
    {
        #region Field

        protected ComponentBaseGUI<T> gui;

        #endregion Field

        #region Property

        public System.Object Data
        {
            get;
            private set;
        }

        public FieldInfo FieldInfo
        {
            get;
            private set;
        }

        public FieldGUIAttribute GUIAttribute
        {
            get;
            private set;
        }

        #endregion Property

        #region Constructor

        public FieldGUIBase(System.Object data, FieldInfo fieldInfo, FieldGUIAttribute guiAttribute)
        {
            this.Data = data;
            this.FieldInfo = fieldInfo;
            this.GUIAttribute = guiAttribute;

            InitializeGUI();

            Load();
        }

        #endregion Constrcutor

        #region Method

        public virtual void Show()
        {
            this.gui.Show();
            Save();
        }

        protected virtual void Save()
        {
            this.FieldInfo.SetValue(this.Data, this.gui.Value);
        }

        protected virtual void Load()
        {
            this.gui.Value = (T)this.FieldInfo.GetValue(this.Data);
        }

        protected abstract void InitializeGUI();

        #endregion Method
    }
}