namespace XJGUI
{
    public class BaseGUI<T>
    {
        #region Property

        public virtual T      Value { get; set; }
        public virtual string Title { get; set; }

        #endregion Property

        #region Constructor

        public BaseGUI()
        {
            // NOTE:
            // "Value" must be initialized in inheritance class.

            this.Title = XJGUILayout.DefaultTitle;
        }

        #endregion Constructor
    }
}