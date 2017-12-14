using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Filed

        protected object data;
        protected FieldInfo fieldInfo;
        protected FieldGUIInfo guiInfo;

        #endregion Field

        #region Property

        public bool IsUnsupported { get; protected set; }

        public int UpdateIndex { get; protected set; }

        public System.Type Type { get; protected set; }

        public bool IsIListType { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIBase(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            this.data = data;
            this.fieldInfo = fieldInfo;
            this.guiInfo = guiInfo;

            InitializeGUI();
            Load();
        }

        #endregion Constrcutor

        #region Method

        protected abstract void InitializeGUI();

        protected abstract void Save();

        protected abstract void Load();

        protected abstract void ShowGUI();

        public abstract void SetValue(object value, int index = -1);

        public abstract object GetValue();

        public void Show()
        {
            ShowGUI();
            Save();
        }

        #endregion Method
    }
}