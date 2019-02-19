using UnityEngine;

namespace XJGUI
{
    public abstract class ValueGUI<T> : TextFieldGUI<T> where T : struct
    {
        #region Property

        public virtual T     MinValue   { get; set; }
        public virtual T     MaxValue   { get; set; }
        public virtual int   Decimals   { get; set; }
        public virtual bool  WithSlider { get; set; }

        protected override GUIStyle FieldStyle
        {
            get
            {
                GUIStyle style = base.FieldStyle;
                style.alignment = TextAnchor.MiddleRight;
                return style;
            }
        }

        #endregion Property

        #region Constructor

        public ValueGUI() : base()
        {
            base.FieldWidth = XJGUILayout.DefaultFieldWidthValue;
            this.Decimals   = XJGUILayout.DefaultDecimals;
            this.WithSlider = XJGUILayout.DefaultWithSlider;
        }

        #endregion Constructor
    }
}