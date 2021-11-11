namespace XGUI
{
    public abstract class ElementGUI<T> : ComponentGUI
    {
        #region Constructor

        protected ElementGUI() { }

        protected ElementGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public abstract T Show(T value);

        #endregion Method
    }
}