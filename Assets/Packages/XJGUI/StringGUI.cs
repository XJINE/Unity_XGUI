namespace XJGUI
{
    public class StringGUI : TextFieldGUI<string>
    {
        #region Constructor

        public StringGUI() : base() { }

        public StringGUI(string title) : base(title) { }

        public StringGUI(string title, string value) : base(title, value) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            base.Value      = XJGUILayout.DefaultValueString;
            this.FieldWidth = XJGUILayout.DefaultFieldWidthString;
        }

        public override string Show(string value)
        {
            XJGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();
                base.Value = base.ShowTextField(value);
            });

            return base.Value;
        }

        #endregion Method
    }
}