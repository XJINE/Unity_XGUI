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

                if (!int.TryParse(Text, out value))
                {
                    return false;
                }

                return base.MinValue <= value && value <= base.MaxValue;
            }
        }

        #endregion Property

        #region Constructor

        public IntGUI() { }

        public IntGUI(string title) : base(title) { }
 
        public IntGUI(string title, int min, int max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueInt;
            MaxValue = XGUILayout.DefaultMaxValueInt;
        }

        #endregion Method
    }
}