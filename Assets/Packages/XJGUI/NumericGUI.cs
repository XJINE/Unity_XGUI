using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be 'int' or 'float'.

    public abstract class NumericGUI<T> : ValueGUI<T> where T : struct, IComparable
    {
        #region Field

        protected string text;

        #endregion Field

        #region Property

        public override T Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = CorrectValue(value);
                this.text = base.Value.ToString();
            }
        }

        public override T MinValue
        {
            get
            {
                return base.MinValue;
            }
            set
            {
                base.MinValue = value;
                this.Value = base.Value;
            }
        }

        public override T MaxValue
        {
            get
            {
                return base.MaxValue;
            }
            set
            {
                base.MaxValue = value;
                this.Value = base.Value;
            }
        }

        protected override GUIStyle FieldStyle
        {
            get
            {
                GUIStyle style = base.FieldStyle;

                bool textIsCorrect = TextIsCorrect;

                style.normal.textColor
                = textIsCorrect ? GUI.skin.textField.normal.textColor
                                : XJGUILayout.DefaultInvalidValueColor;

                style.active.textColor
                = textIsCorrect ? GUI.skin.textField.active.textColor
                                : XJGUILayout.DefaultInvalidValueColor;

                style.focused.textColor
                = textIsCorrect ? GUI.skin.textField.focused.textColor
                                : XJGUILayout.DefaultInvalidValueColor;

                return style;
            }
        }

        protected abstract bool TextIsCorrect { get; }

        #endregion Property

        #region Constructor

        public NumericGUI() : base() { }

        public NumericGUI(string title) : base(title) { }

        public NumericGUI(string title, T value) : base(title, value) { }

        public NumericGUI(string title, T value, T min, T max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    this.text = base.ShowTextField(this.text);

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    float textValue;

                    if (float.TryParse(this.text, out textValue))
                    {
                        base.Value = (T)Convert.ChangeType(textValue, typeof(T));
                    }
                });

                if (!base.WithSlider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                float value    = (float)Convert.ChangeType(base.Value,    typeof(float));
                float minValue = (float)Convert.ChangeType(base.MinValue, typeof(float));
                float maxValue = (float)Convert.ChangeType(base.MaxValue, typeof(float));

                float sliderValue = GUILayout.HorizontalSlider(value, minValue, maxValue);

                T sliderValueT = (T)Convert.ChangeType(sliderValue, typeof(T));

                if (!sliderValueT.Equals(base.Value))
                {
                    this.Value = sliderValueT;
                }
            });

            return base.Value;
        }

        protected virtual T CorrectValue(T value)
        {
            if (0 < value.CompareTo(base.MaxValue))
            {
                value = base.MaxValue;
            }

            if (value.CompareTo(base.MinValue) < 0)
            {
                value = base.MinValue;
            }

            return value;
        }

        #endregion Method
    }
}