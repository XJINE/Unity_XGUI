using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Property

        protected System.Object data;
        protected FieldInfo info;
        protected FieldGUIInfo attribute;

        #endregion Property

        #region Constructor

        public FieldGUIBase(System.Object data, FieldInfo info, FieldGUIInfo attribute)
        {
            this.data = data;
            this.info = info;
            this.attribute = attribute;

            InitializeGUI();
            Load();
        }

        #endregion Constrcutor

        #region Method

        protected abstract void InitializeGUI();

        protected abstract void Save();

        protected abstract void Load();

        protected abstract void ShowGUI();

        public void Show()
        {
            ShowGUI();
            Save();
        }

        #endregion Method
    }
}