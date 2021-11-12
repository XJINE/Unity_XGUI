namespace XGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Property

        public virtual int Digits { get; set; }

        protected override bool TextIsCorrect
        {
            get
            {
                float value;

                if (!float.TryParse(Text, out value))
                {
                    return false;
                }

                if (value < MinValue || MaxValue < value)
                {
                    return false;
                }

                var splits = Text.Split('.');

                if (splits.Length == 1)
                {
                    return true;
                }

                return splits[1].Length <= Digits;
            }
        }

        #endregion Property

        #region Constructor

        public FloatGUI() { }

        public FloatGUI(string title) : base(title) { }

        public FloatGUI(string title, float min, float max) : base(title, min , max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            Digits   = XGUILayout.DefaultDigits;
            MinValue = XGUILayout.DefaultMinValueFloat;
            MaxValue = XGUILayout.DefaultMaxValueFloat;
        }

        protected override float ValidateValue(float value)
        {
            return (float)System.Math.Round(base.ValidateValue(value), Digits);
        }

        #endregion Method
    }
}