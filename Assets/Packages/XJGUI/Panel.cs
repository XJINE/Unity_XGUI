namespace XJGUI
{
    public abstract class Panel<T> : Component<T>
    {
        // NOTE:
        // There is no common member in each panel now.

        #region Constructor

        public Panel() : base() { }

        public Panel(string title) : base(title) { }

        public Panel(string title, T value) : base(title, value) { }

        #endregion Constructor
    }
}