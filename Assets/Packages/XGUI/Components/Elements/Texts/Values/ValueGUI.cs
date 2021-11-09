using UnityEngine;

namespace XGUI
{
    public abstract class ValueGUI<T> : TextFieldGUI<T> where T : struct
    {
        #region Property

        public virtual T    MinValue { get; set; }
        public virtual T    MaxValue { get; set; }
        public virtual bool Slider   { get; set; }

        protected override GUIStyle FieldStyle
        {
            get
            {
                var style = base.FieldStyle;
                style.alignment = TextAnchor.MiddleRight;
                return style;
            }
        }

        #endregion Property

        #region Constructor

        protected ValueGUI() { }

        protected ValueGUI(string title) : base(title) { }

        protected ValueGUI(string title, T min, T max) : base(title)
        {
            MinValue = min;
            MaxValue = max;
        }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            Width  = XGUILayout.DefaultWidth;
            Slider = XGUILayout.DefaultSlider;
        }

        #endregion Method
    }
}