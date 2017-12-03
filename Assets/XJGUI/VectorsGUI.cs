namespace XJGUI
{
    public abstract class VectorsGUI<T> : ValuesGUI<T> where T : struct
    {
        #region Property

        public int DecimalPlaces { get; set; }

        public virtual bool Horizontal { get; set; }

        #endregion Property
    }
}