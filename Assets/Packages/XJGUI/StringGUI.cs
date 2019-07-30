namespace XJGUI
{
    public class StringGUI : TextFieldGUI<string>
    {
        #region Constructor

        public StringGUI() : base() { }

        public StringGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            this.Width = XJGUILayout.DefaultWidth;
        }

        public override string Show(string value)
        {
            XJGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();
                value = base.ShowTextField(value);
            });

            return value;
        }

        #endregion Method
    }
}