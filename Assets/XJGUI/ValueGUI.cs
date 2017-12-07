namespace XJGUI
{
    public abstract class ValueGUI<T> : ElementGUI<T> where T : struct
    {
        #region Field

        protected T minValue;
        protected T maxValue;
        protected int decimals;
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

        public virtual int Decimals
        {
            get { return this.decimals; }
            set { this.decimals = value; }
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
            // "minValue" & "maxValue" must be initialized in inheritance class.

            this.decimals = 2;
            this.textFieldWidth = 0;
            this.withSlider = true;
        }

        #endregion Constructor
    }
}