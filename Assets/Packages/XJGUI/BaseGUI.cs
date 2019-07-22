namespace XJGUI
{
    public abstract class BaseGUI<T>
    {
        #region Property

        protected virtual T      Value { get; set; }
        public    virtual string Title { get; set; }

        #endregion Property

        #region Constructor

        public BaseGUI()
        {
            Initialize();
            Title = XJGUILayout.DefaultTitle;
        }

        public BaseGUI(string title)
        {
            Initialize();
            Title = title;
        }

        #endregion Constructor

        #region Method

        protected virtual void Initialize() { }

        #endregion Method
    }
}