namespace XGUI
{
    public abstract class BaseGUI<T>
    {
        #region Property

        public virtual string Title { get; set; }

        #endregion Property

        #region Constructor

        protected BaseGUI() : this (XGUILayout.DefaultTitle) { }

        protected BaseGUI(string title)
        {
            Title = title;
            Initialize();
        }

        #endregion Constructor

        #region Method

        protected virtual void Initialize() { }

        #endregion Method
    }
}