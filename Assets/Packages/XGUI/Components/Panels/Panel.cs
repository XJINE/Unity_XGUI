namespace XGUI
{
    public abstract class Panel<T> : Component
    {
        #region Field

        public T Value;

        #endregion Field

        #region Constructor

        protected Panel() { }

        protected Panel(string title) : base(title) { }

        #endregion Constructor
    }
}