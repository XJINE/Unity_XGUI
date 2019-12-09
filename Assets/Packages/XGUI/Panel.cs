namespace XGUI
{
    public abstract class Panel<T> : Component<T>
    {
        #region Property

        protected T value;
        public    T Value { set { this.value = value; } }

        #endregion Property

        #region Constructor

        public Panel() : base() { }

        public Panel(string title) : base(title) { }

        #endregion Constructor
    }
}