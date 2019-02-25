namespace XJGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Constructor

        public VectorGUI() : base() { }

        public VectorGUI(string title) : base(title) { }

        public VectorGUI(string title, T value) : base(title, value) { }

        public VectorGUI(string title, T value, T min, T max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() =>
                {
                    ShowComponents();
                });
            });

            return base.Value;
        }

        protected abstract void ShowComponents();

        #endregion Method
    }
}