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

        protected override ElementGUI<float> GenerateGUI()
        {
            return new FloatGUI();
        }

        #endregion Method
    }
}