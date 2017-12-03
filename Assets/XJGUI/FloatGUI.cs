namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Property

        public int Decimals { get; set; }

        #endregion Property

        #region Constructor

        public FloatGUI() : base()
        {
            this.Decimals = 2;
        }

        #endregion Constructor

        #region Method

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), this.Decimals);
        }

        #endregion Method
    }
}