namespace XJGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Property

        public virtual int Decimals
        {
            get; set;
        }

        public virtual bool Horizontal
        {
            get; set;
        }

        #endregion Property
    }
}