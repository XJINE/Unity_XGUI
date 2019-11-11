namespace XGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Property

        public virtual int Decimals { get; set; }

        protected override bool TextIsCorrect
        {
            get
            {
                float value;

                if (!float.TryParse(this.text, out value))
                {
                    return false;
                }

                if (value < base.MinValue || base.MaxValue < value)
                {
                    return false;
                }

                string[] splits = this.text.Split('.');

                if (splits.Length == 1)
                {
                    return true;
                }

                if (splits[1].Length <= this.Decimals)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion Property

        #region Constructor

        public FloatGUI() : base() { }

        public FloatGUI(string title) : base(title) { }

        public FloatGUI(string title, float min, float max) : base(title, min , max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.Decimals = XGUILayout.DefaultDecimals;
            base.MinValue = XGUILayout.DefaultMinValueFloat;
            base.MaxValue = XGUILayout.DefaultMaxValueFloat;
        }

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), this.Decimals);
        }

        #endregion Method
    }
}