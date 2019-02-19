namespace XJGUI
{
    public class IntGUI : NumericGUI<int>
    {
        #region Property

        protected override bool TextIsCorrect
        {
            get
            {
                int value;

                if (!int.TryParse(this.text, out value))
                {
                    return false;
                }

                if (value < base.MinValue || base.MaxValue < value)
                {
                    return false;
                }

                return true;
            }
        }

        #endregion Property

        #region Constructor

        public IntGUI() : base()
        {
            base.MinValue = XJGUILayout.DefaultMinValueInt;
            base.MaxValue = XJGUILayout.DefaultMaxValueInt;
            base.Value    = XJGUILayout.DefaultValueInt;
        }

        #endregion Constructor
    }
}