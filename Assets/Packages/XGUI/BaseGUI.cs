namespace XGUI
{
    public abstract class BaseGUI<T>
    {
        #region Property

        public virtual string Title { get; set; }

        #endregion Property

        #region Constructor

        public BaseGUI() : this (XGUILayout.DefaultTitle) { }

        public BaseGUI(string title)
        {
            this.Title = title;
            Initialize();
        }

        #endregion Constructor

        #region Method

        protected virtual void Initialize() { }

        #endregion Method
    }
}