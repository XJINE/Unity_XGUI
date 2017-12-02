namespace XJGUI
{
    public abstract class ValueGUI<T> : AbstractGUI<T>
    {
        #region Field

        public T minValue;
        public T maxValue;

        public int textFieldWidth = -1;
        public bool withSlider = true;

        private string text = null;
        private bool textIsValid = true;

        #endregion Field

        #region Constructor

        public ValueGUI()
        {
            InitializeMinMaxValue();
        }

        #endregion Constructor

        #region Method

        protected abstract void InitializeMinMaxValue();

        #endregion Method
    }
}