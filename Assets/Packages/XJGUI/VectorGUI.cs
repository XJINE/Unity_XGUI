namespace XJGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Constructor

        public VectorGUI() : base() { }

        public VectorGUI(string title) : base(title) { }

        public VectorGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show(T value)
        {
            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() =>
                {
                    value = ShowComponents(value);
                });
            });

            return value;
        }

        protected abstract T ShowComponents(T value);

        #endregion Method
    }
}