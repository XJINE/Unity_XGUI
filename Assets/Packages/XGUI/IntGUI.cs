namespace XGUI
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

        public IntGUI() : base() { }

        public IntGUI(string title) : base(title) { }
 
        public IntGUI(string title, int min, int max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            base.MinValue = XGUILayout.DefaultMinValueInt;
            base.MaxValue = XGUILayout.DefaultMaxValueInt;
        }

        #endregion Method
    }
}