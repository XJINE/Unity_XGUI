namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Field

        public int decimals = 2;

        #endregion Field

        #region Method

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), decimals);
        }

        #endregion Method
    }
}