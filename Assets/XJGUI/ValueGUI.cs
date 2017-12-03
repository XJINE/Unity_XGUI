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
    }
}