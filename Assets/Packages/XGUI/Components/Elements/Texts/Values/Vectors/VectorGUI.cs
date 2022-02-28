namespace XGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Constructor

        protected VectorGUI() { }

        protected VectorGUI(string title) : base(title) { }

        protected VectorGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show(T value)
        {
            var previousValue = value;

            XGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                XGUILayout.HorizontalLayout(() =>
                {
                    value = ShowComponents(value);
                });
            });

            Updated = !previousValue.Equals(value);

            return value;
        }

        protected abstract T ShowComponents(T value);

        #endregion Method
    }
}