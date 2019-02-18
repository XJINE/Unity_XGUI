namespace XJGUI
{
    public class IntGUI : NumericGUI<int>
    {
        #region Property

        public override int Decimals
        {
            get
            {
                return base.Decimals;
            }
            set
            {
                base.Decimals = 0;
            }
        }

        #endregion Property

        #region Constructor

        public IntGUI() : base()
        {
            base.MinValue = XJGUILayout.DefaultMinValueInt;
            base.MaxValue = XJGUILayout.DefaultMaxValueInt;
            this.Value    = XJGUILayout.DefaultValueInt;
        }

        #endregion Constructor

        #region Method

        protected override bool TextIsCorrect()
        {
            int value;

            if (!int.TryParse(this.text, out value))
            {
                return false;
            }

            if (value < base.MinValue)
            {
                return false;
            }

            if (value > base.MaxValue)
            {
                return false;
            }

            return true;
        }

        #endregion Method
    }
}