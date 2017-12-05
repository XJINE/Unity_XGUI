namespace XJGUI
{
    public abstract class VectorsGUI<T> : FloatingPointValueGUI<T> where T : struct
    {
        #region Field

        public bool horizontal;

        #endregion Field

        #region Property

        public virtual bool Horizontal
        {
            get { return this.horizontal; }
            set { this.horizontal = true; }
        }

        #endregion Property
    }
}