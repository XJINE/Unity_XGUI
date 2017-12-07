namespace XJGUI
{
    public class IntsGUI : ValuesGUI<int>
    {
        #region Constructor

        public IntsGUI()
        {
            base.minValue = int.MinValue;
            base.maxValue = int.MaxValue;
        }

        #endregion Constructor

        #region Method

        protected override ValueGUI<int> GenerateValueGUI()
        {
            return new IntGUI();
        }

        #endregion Method
    }
}