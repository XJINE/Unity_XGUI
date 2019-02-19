using System;

namespace XJGUI
{
    public abstract class FloatingPointNumericGUI<T> : NumericGUI<T> where T : struct, IComparable
    {
        #region Property

        public virtual int Decimals { get; set; }

        #endregion Property

        #region Constructor

        public FloatingPointNumericGUI() : base()
        {
            this.Decimals = XJGUILayout.DefaultDecimals;
        }

        #endregion Constructor
    }
}