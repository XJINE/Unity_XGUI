using UnityEngine;

namespace XJGUI
{
    public abstract class ValueGUI<T> : ElementGUI<T> where T : struct
    {
        #region Property

        public virtual T     MinValue   { get; set; }
        public virtual T     MaxValue   { get; set; }
        public virtual int   Decimals   { get; set; }
        public virtual float FieldWidth { get; set; }
        public virtual bool  WithSlider { get; set; }

        protected virtual GUIStyle TextFieldStyle
        {
            get
            {
                return new GUIStyle(GUI.skin.textField)
                {
                    alignment = TextAnchor.MiddleRight
                };
            }
        }

        #endregion Property

        #region Constructor

        public ValueGUI() : base()
        {
            // NOTE:
            // "MinValue" & "MaxValue" must be initialized in inheritance class.

            this.Decimals   = XJGUILayout.DefaultDecimals;
            this.FieldWidth = XJGUILayout.DefaultFieldWidth;
            this.WithSlider = XJGUILayout.DefaultWithSlider;
        }

        #endregion Constructor
    }
}