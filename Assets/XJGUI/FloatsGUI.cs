namespace XJGUI
{
    public class FloatsGUI : ValuesGUI<float>
    {
        #region Method

        protected override ValueGUI<float> GenerateValueGUI()
        {
            return new FloatGUI()
            {
                MinValue = base.MinValue,
                MaxValue = base.MaxValue,
                TextFieldWidth = base.TextFieldWidth,
                WithSlider = base.WithSlider
            };
        }

        #endregion Method
    }
}