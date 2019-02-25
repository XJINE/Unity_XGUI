namespace XJGUI
{
    public abstract class BaseGUI<T>
    {
        #region Property

        public virtual T      Value { get; set; }
        public virtual string Title { get; set; }

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

        public BaseGUI(string title, T value)
        {
            Initialize();
            Title = title;
            Value = value;
        }

        #endregion Constructor

        #region Method

        protected virtual void Initialize() { }

        #endregion Method
    }
}