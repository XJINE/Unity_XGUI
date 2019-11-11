namespace XGUI
{
    public abstract class VectorFloatGUI<T> : VectorGUI<T> where T : struct
    {
        #region Property

        public virtual int Decimals { get; set; }

        #endregion Property

        #region Constructor

        public VectorFloatGUI() : base() { }

        public VectorFloatGUI(string title) : base(title) { }

        public VectorFloatGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor
    }
}