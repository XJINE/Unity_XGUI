namespace XGUI
{
    public abstract class BaseGUI
    {
        #region Property

        public virtual string Title { get; set; }

        #endregion Property

        #region Constructor

        protected BaseGUI() : this (XGUILayout.DefaultTitle) { }

        protected BaseGUI(string title)
        {
            // CAUTION:
            // Initialize first, because some inheritance initialize the GUI in Initialize.

            Initialize();
            Title = title;
        }

        #endregion Constructor

        #region Method

        protected virtual void Initialize() { }

        #endregion Method
    }
}