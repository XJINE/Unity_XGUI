using System;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // T must be 'int' or 'float'.

    public abstract class NumericGUI<T> : ValueGUI<T> where T : struct, IComparable
    {
        #region Field

        protected T PreviousValue;

        protected string Text;

        #endregion Field

        #region Property

        protected override GUIStyle FieldStyle
        {
            get
            {
                var style     = base.FieldStyle;
                var textColor = TextIsCorrect ? GUI.skin.textField.normal.textColor
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

        protected NumericGUI() { }

        protected NumericGUI(string title) : base(title) { }

        protected NumericGUI(string title, T min, T max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        public override T Show(T value)
        {
            Text ??= value.ToString();
            Text = PreviousValue.Equals(value) ? Text : value.ToString();

            XGUILayout.VerticalLayout(() =>
            {
                XGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    Text = ShowTextField(Text);

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    if (float.TryParse(Text, out float textValue))
                    {
                        value = (T)Convert.ChangeType(textValue, typeof(T));
                    }
                });

                if (!Slider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                var floatValue = (float)Convert.ChangeType(value,   typeof(float));
                var minValue   = (float)Convert.ChangeType(MinValue, typeof(float));
                var maxValue   = (float)Convert.ChangeType(MaxValue, typeof(float));

                var sliderValue  = GUILayout.HorizontalSlider(floatValue, minValue, maxValue);
                var sliderValueT = ValidateValue((T)Convert.ChangeType(sliderValue, typeof(T)));

                if (!sliderValueT.Equals(value))
                {
                    value = sliderValueT;
                    Text   = value.ToString();
                }
            });

            PreviousValue = value;

            return value;
        }

        protected virtual T ValidateValue(T value)
        {
            if (0 < value.CompareTo(MaxValue))
            {
                value = MaxValue;
            }

            if (value.CompareTo(MinValue) < 0)
            {
                value = MinValue;
            }

            return value;
        }

        #endregion Method
    }
}