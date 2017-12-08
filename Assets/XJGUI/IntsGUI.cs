namespace XJGUI
{
    public class IntsGUI : ValuesGUI<int>
    {
        #region Constructor

        public IntsGUI()
        {
            base.minValue = XJGUILayout.DefaultMinValueInt;
            base.maxValue = XJGUILayout.DefaultMaxValueInt;
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