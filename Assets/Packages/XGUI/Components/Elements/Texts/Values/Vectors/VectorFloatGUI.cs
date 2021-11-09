namespace XGUI
{
    public abstract class VectorFloatGUI<T> : VectorGUI<T> where T : struct
    {
        #region Property

        public virtual int Digits { get; set; }

        #endregion Property

        #region Constructor

        protected VectorFloatGUI() { }

        protected VectorFloatGUI(string title) : base(title) { }

        protected VectorFloatGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor
    }
}