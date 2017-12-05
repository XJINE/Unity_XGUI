using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be 'int' or 'float'.

    public abstract class NumericGUI<T> : ValueGUI<T> where T : struct, IComparable
    {
        #region Field

        protected string text = null;

        #endregion Field

        #region Property

        public override T Value
        {
            get
            {
                return base.value;
            }
            set
            {
                base.value = CorrectValue(value);
                this.text = base.value.ToString();
            }
        }

        #endregion Property

        #region Constructor

        public NumericGUI() : base()
        {
            this.Value = (T)Convert.ChangeType(0, typeof(T));

            base.MinValue = (T)(typeof(T).GetField("MinValue").GetValue(null));
            base.MaxValue = (T)(typeof(T).GetField("MaxValue").GetValue(null));
            base.TextFieldWidth = -1;
            base.WithSlider = true;
        }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                // TextField

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    this.text = GUILayout.TextField(this.text, base.TextFieldWidth <= 0 ?
                                GUILayout.ExpandWidth(true) : GUILayout.Width(base.TextFieldWidth));

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    float textFieldValue;

                    if (float.TryParse(this.text, out textFieldValue))
                    {
                        base.value = CorrectValue((T)Convert.ChangeType(textFieldValue, typeof(T)));
                    }
                });

                // Slider

                if (!base.WithSlider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                float floatValue = Convert.ToSingle(base.value);
                float floatMinValue = Convert.ToSingle(base.MinValue);
                float floatMaxValue = Convert.ToSingle(base.MaxValue);

                float sliderValue = GUILayout.HorizontalSlider(floatValue, floatMinValue, floatMaxValue);

                if (sliderValue != floatValue)
                {
                    this.Value = (T)Convert.ChangeType(sliderValue, typeof(T));
                }
            });

            return this.Value;
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