namespace XJGUI
{
    public abstract class VectorFloatGUI<T> : VectorGUI<T> where T : struct
    {
        #region Property

        public virtual int Decimals { get; set; }

        #endregion Property
    }
}