namespace XJGUI
{
    public class BaseGUI<T>
    {
        #region Field

        protected T value;
        protected string title;

        #endregion Field

        #region Property

        public virtual T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public virtual string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        #endregion Property

        #region Constructor

        public BaseGUI()
        {
            this.title = null;
        }

        #endregion Constructor
    }
}