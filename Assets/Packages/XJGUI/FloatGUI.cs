namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Constructor

        public FloatGUI() : base()
        {
            base.MinValue = XJGUILayout.DefaultMinValueFloat;
            base.MaxValue = XJGUILayout.DefaultMaxValueFloat;
            base.Value    = XJGUILayout.DefaultValueFloat;
        }

        #endregion Constructor

        #region Method

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), base.Decimals);
        }

        protected override bool TextIsCorrect()
        {
            float value;

            if (!float.TryParse(this.text, out value))
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

            string[] splits = this.text.Split('.');

            if (splits.Length == 1)
            {
                return true;
            }

            if (splits[1].Length <= base.Decimals)
            {
                return true;
            }

            return false;
        }

        #endregion Method
    }
}