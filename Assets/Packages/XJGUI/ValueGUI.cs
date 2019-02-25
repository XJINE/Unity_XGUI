using UnityEngine;

namespace XJGUI
{
    public abstract class ValueGUI<T> : TextFieldGUI<T> where T : struct
    {
        #region Property

        public virtual T    MinValue   { get; set; }
        public virtual T    MaxValue   { get; set; }
        public virtual bool WithSlider { get; set; }

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

        public ValueGUI() : base() { }

        public ValueGUI(string title) : base(title) { }

        public ValueGUI(string title, T value) : base(title, value) { }

        public ValueGUI(string title, T value, T min, T max) : base(title, value)
        {
            this.MinValue = min;
            this.MaxValue = max;
        }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            base.FieldWidth = XJGUILayout.DefaultFieldWidthValue;
            this.WithSlider = XJGUILayout.DefaultWithSlider;
        }

        #endregion Method
    }
}