namespace XJGUI
{
    public class FloatsGUI : ValuesGUI<float>
    {
        #region Constructor

        public FloatsGUI()
        {
            base.minValue = XJGUILayout.DefaultMinValueFloat;
            base.maxValue = XJGUILayout.DefaultMaxValueFloat;
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