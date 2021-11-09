namespace XGUI
{
    public abstract class Element<T> : Component
    {
        #region Constructor

        protected Element() { }

        protected Element(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public abstract T Show(T value);

        #endregion Method
    }
}