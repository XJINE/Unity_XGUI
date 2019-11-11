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
                GUIStyle style = base.FieldStyle;
                style.alignment = TextAnchor.MiddleRight;
                return style;
            }
        }

        #endregion Property

        #region Constructor

        public ValueGUI() : base() { }

        public ValueGUI(string title) : base(title) { }

        public ValueGUI(string title, T min, T max) : base(title)
        {
            this.MinValue = min;
            this.MaxValue = max;
        }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            base.Width = XGUILayout.DefaultWidth;
            this.Slider     = XGUILayout.DefaultSlider;
        }

        #endregion Method
    }
}