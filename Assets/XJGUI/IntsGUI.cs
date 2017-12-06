namespace XJGUI
{
    public class IntsGUI : ValuesGUI<int>
    {
        #region Method

        protected override ValueGUI<int> GenerateValueGUI()
        {
            return new IntGUI()
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