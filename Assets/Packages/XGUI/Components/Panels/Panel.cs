namespace XGUI
{
    public abstract class Panel<T> : ComponentGUI
    {
        #region Field

        public T    Value;
        public bool BoxSkin = true;

        #endregion Field

        #region Constructor

        protected Panel() { }

        protected Panel(string title) : base(title) { }

        #endregion Constructor
    }
}