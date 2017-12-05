namespace XJGUI
{
    public abstract class FloatingPointValueGUI<T> : ValueGUI<T> where T : struct
    {
        #region Field

        protected int decimals;

        #endregion Field

        #region Property

        public virtual int Decimals
        {
            get { return this.decimals; }
            set { this.decimals = value; }
        }

        #endregion Property

        #region Constructor

        public FloatingPointValueGUI() : base()
        {
            this.Decimals = 2;
        }

        #endregion Constructor
    }
}