namespace XGUI
{
    public abstract class Element<T> : Component<T>
    {
        #region Constructor

        public Element() : base() { }

        public Element(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public abstract T Show(T value);

        #endregion Method
    }
}