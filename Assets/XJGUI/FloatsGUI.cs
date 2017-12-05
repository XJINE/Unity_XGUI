namespace XJGUI
{
    public class FloatsGUI : ValuesGUI<float>
    {
        #region Method

        protected override ValueGUI<float> GenerateValueGUI()
        {
            return new FloatGUI()
            {
                MinValue = base.minValue,
                MaxValue = base.maxValue,
                TextFieldWidth = base.textFieldWidth,
                WithSlider = base.withSlider
            };
        }

        #endregion Method
    }
}