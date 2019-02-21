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
            this.Title = XJGUILayout.DefaultTitle;
        }

        public BaseGUI(string title)
        {
            this.Title = title;
        }

        #endregion Constructor
    }
}