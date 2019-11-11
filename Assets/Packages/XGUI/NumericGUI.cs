using System;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // T must be 'int' or 'float'.

    public abstract class NumericGUI<T> : ValueGUI<T> where T : struct, IComparable
    {
        #region Field

        protected T previousValue;

        protected string text;

        #endregion Field

        #region Property

        protected override GUIStyle FieldStyle
        {
            get
            {
                GUIStyle style = base.FieldStyle;
                Color textColor = TextIsCorrect ? GUI.skin.textField.normal.textColor
                                                : XGUILayout.DefaultInvalidValueColor;
                style.normal.textColor  = textColor;
                style.active.textColor  = textColor;
                style.focused.textColor = textColor;

                return style;
            }
        }

        protected abstract bool TextIsCorrect { get; }

        #endregion Property

        #region Constructor

        public NumericGUI() : base() { }

        public NumericGUI(string title) : base(title) { }

        public NumericGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show(T value)
        {
            T valueT = value;

            this.text = this.text ?? valueT.ToString();
            this.text = this.previousValue.Equals(valueT) ?
                        this.text : valueT.ToString();

            XGUILayout.VerticalLayout(() =>
            {
                XGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    this.text = base.ShowTextField(this.text);

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    if (float.TryParse(this.text, out float textValue))
                    {
                        valueT = (T)Convert.ChangeType(textValue, typeof(T));
                    }
                });

                if (!base.Slider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                float floatValue = (float)Convert.ChangeType(valueT,        typeof(float));
                float minValue   = (float)Convert.ChangeType(base.MinValue, typeof(float));
                float maxValue   = (float)Convert.ChangeType(base.MaxValue, typeof(float));

                float sliderValue = GUILayout.HorizontalSlider(floatValue, minValue, maxValue);

                T sliderValueT = CorrectValue((T)Convert.ChangeType(sliderValue, typeof(T)));

                if (!sliderValueT.Equals(valueT))
                {
                    valueT = sliderValueT;
                    this.text = valueT.ToString();
                }
            });

            this.previousValue = valueT;

            return valueT;
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