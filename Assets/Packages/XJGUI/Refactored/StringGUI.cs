namespace XJGUI
{
    public class StringGUI : TextFieldGUI<string>
    {
        #region Constructor

        public StringGUI()
        {
            base.Value      = XJGUILayout.DefaultValueString;
            this.FieldWidth = XJGUILayout.DefaultFieldWidthString;
        }

        #endregion Constructor

        #region Method

        public override string Show()
        {
            XJGUILayout.HorizontalLayout(() => 
            {
                base.ShowTitle();
                base.Value = base.ShowTextField(base.Value);
            });

            return base.Value;
        }

        #endregion Method
    }
}