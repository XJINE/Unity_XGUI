namespace XJGUI
{
    public class IntsGUI : ValuesGUI<int>
    {
        #region Method

        protected override ValueGUI<int> GenerateValueGUI()
        {
            return new IntGUI()
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