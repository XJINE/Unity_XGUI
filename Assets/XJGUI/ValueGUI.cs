namespace XJGUI
{
    public abstract class ValueGUI<T> : AbstractGUI<T> where T : struct
    {
        #region Field

        public T minValue;
        public T maxValue;

        public float textFieldWidth = -1;
        public bool withSlider = true;

        protected string text = null;
        protected bool textIsValid = true;

        #endregion Field

        #region Constructor

        public ValueGUI()
        {
            InitializeMinMaxValue();

            // NOTE:
            // It seems good, but have a problem.
            // Vector2 or Vector3 and any other Unity "value" has no "MinValue" or "MaxValue".
            // 
            // this.minValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
            // this.maxValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
        }

        #endregion Constructor

        #region Method

        protected abstract void InitializeMinMaxValue();

        #endregion Method
    }
}