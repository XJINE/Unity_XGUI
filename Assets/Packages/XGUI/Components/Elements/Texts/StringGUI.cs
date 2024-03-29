﻿namespace XGUI
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
            var previousValue = value;

            XGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();
                value = ShowTextField(value);
            });

            Updated = previousValue != value;

            return value;
        }

        #endregion Method
    }
}