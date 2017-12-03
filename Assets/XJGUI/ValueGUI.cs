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
            // NOTE:
            // It seems good, but have a problem.
            // Vector2 or Vector3 and any other Unity "value" has no "MinValue" or "MaxValue".
            // 
            // this.MinValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
            // this.MaxValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
        }

        #endregion Constructor
    }
}