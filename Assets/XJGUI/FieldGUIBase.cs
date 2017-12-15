using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Filed

        protected object data;
        protected FieldInfo fieldInfo;
        protected FieldGUIInfo guiInfo;
        protected int updateIndex;

        #endregion Field

        #region Property

        public bool IsUnsupported { get; protected set; }

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

        public abstract void SetSyncValue(int index, string value);

        public abstract void GetSyncValue(out int index, out string value);

        public void Show()
        {
            ShowGUI();
            Save();
        }

        #endregion Method
    }
}