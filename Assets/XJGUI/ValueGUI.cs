namespace XJGUI
{
    public abstract class ValueGUI<T> : AbstractGUI<T> where T : struct
    {
        #region Property

        public virtual T MinValue { get; set; }

        public virtual T MaxValue { get; set; }

        public virtual float TextFieldWidth { get; set; }

        public virtual bool WithSlider { get; set; }

        #endregion Property

        #region Constructor

        public ValueGUI() : base()
        {
            this.TextFieldWidth = -1;
            this.WithSlider = true;

            // NOTE:
            // It seems good, but have a problem.
            // Vector2 or Vector3 and any other Unity "value" has no "MinValue" or "MaxValue".
            // 
            // this.minValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
            // this.maxValue = (T)(typeof(T).GetField("MinValue").GetValue(null));

            InitializeMinMaxValue();
        }

        protected ValueGUI(bool fromInheritance) : base()
        {
            //InitializeMinMaxValue();
        }

        #endregion Constructor

        #region Method

        protected abstract void InitializeMinMaxValue();

        #endregion Method
    }
}