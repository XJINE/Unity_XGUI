namespace XGUI
{
    public class StringGUI : TextFieldGUI<string>
    {
        #region Constructor

        public StringGUI() { }

        public StringGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            Width = XGUILayout.DefaultWidth;
        }

        public override string Show(string value)
        {
            XGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();
                value = ShowTextField(value);
            });

            return value;
        }

        #endregion Method
    }
}