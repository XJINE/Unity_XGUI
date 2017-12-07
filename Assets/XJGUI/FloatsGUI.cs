namespace XJGUI
{
    public class FloatsGUI : ValuesGUI<float>
    {
        #region Constructor

        public FloatsGUI()
        {
            base.minValue = float.MinValue;
            base.maxValue = float.MaxValue;
        }

        #endregion Constructor

        #region Method

        protected override ValueGUI<float> GenerateValueGUI()
        {
            return new FloatGUI();
        }

        #endregion Method
    }
}