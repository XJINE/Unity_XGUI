using UnityEngine;

namespace XJGUI
{
    public abstract class ValueGUI<T> : ElementGUI<T> where T : struct
    {
        #region Field

        protected static GUIStyle TextFieldStyle;

        protected T minValue;
        protected T maxValue;
        protected int decimals;
        protected float fieldWidth;
        protected bool withSlider;

        #endregion Field

        #region Property

        public virtual T MinValue
        {
            get { return this.minValue; }
            set { this.minValue = value; }
        }

        public virtual T MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }

        public virtual int Decimals
        {
            get { return this.decimals; }
            set { this.decimals = value; }
        }

        public virtual float FieldWidth
        {
            get { return this.fieldWidth; }
            set { this.fieldWidth = value; }
        }

        public virtual bool WithSlider
        {
            get { return this.withSlider; }
            set { this.withSlider = value; }
        }

        #endregion Property

        #region Constructor

        public ValueGUI() : base()
        {
            // NOTE:
            // "minValue" & "maxValue" must be initialized in inheritance class.

            this.decimals = XJGUILayout.DefaultDecimals;
            this.fieldWidth = XJGUILayout.DefaultFieldWidth;
            this.withSlider = XJGUILayout.DefaultWithSlider;
        }

        #endregion Constructor

        #region Method

        protected static void InitializeGUIStyle()
        {
            if (ValueGUI<T>.TextFieldStyle == null)
            {
                ValueGUI<T>.TextFieldStyle = new GUIStyle(GUI.skin.textField);
                ValueGUI<T>.TextFieldStyle.alignment = TextAnchor.MiddleRight;
            }
        }

        #endregion Method
    }
}