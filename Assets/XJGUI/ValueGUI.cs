namespace XJGUI
{
    public abstract class ValueGUI<T> : ComponentBaseGUI<T> where T : struct
    {
        #region Field

        protected T minValue;
        protected T maxValue;
        protected float textFieldWidth;
        protected bool withSlider;

        #endregion Field

        #region Property

        public virtual T MinValue
        {
            get { return this.minValue; }
            set { this.minValue = value; }
        }

        public virtual T MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }

        public virtual float TextFieldWidth
        {
            get { return this.textFieldWidth; }
            set { this.textFieldWidth = value; }
        }

        public virtual bool WithSlider
        {
            get { return this.withSlider; }
            set { this.withSlider = value; }
        }

        #endregion Property

        #region Constructor

        public ValueGUI() : base()
        {
            // NOTE:
            // MinValue & MaxValue must be initialized in inheritance class.

            this.TextFieldWidth = -1;
            this.WithSlider = true;
        }

        #endregion Constructor
    }
}