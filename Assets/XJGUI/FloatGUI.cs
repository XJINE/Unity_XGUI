using UnityEngine;

namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Constructor

        public FloatGUI() : base()
        {
            // NOTE:
            // Set min/max value first. If not, "Value" will collect with min/ max value 0.

            base.minValue = XJGUILayout.DefaultMinValueFloat;
            base.maxValue = XJGUILayout.DefaultMaxValueFloat;
            this.Value = XJGUILayout.DefaultValueFloat;
        }

        #endregion Constructor

        #region Method

        public override float Show()
        {
            InitializeGUIStyle();

            XJGUILayout.VerticalLayout(() =>
            {
                // TextField

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle(this.FieldWidth > 0 && base.Title == null);

                    UpdateTextFieldColor();

                    this.text = GUILayout.TextField
                               (this.text, ValueGUI<float>.TextFieldStyle,
                                base.FieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                                     : GUILayout.Width(base.FieldWidth));

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    float textFieldValue;

                    if (float.TryParse(this.text, out textFieldValue))
                    {
                        base.value = CorrectValue(textFieldValue);
                    }
                });

                // Slider

                if (!base.WithSlider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                float sliderValue = (float)GUILayout.HorizontalSlider(this.Value, base.MinValue, base.MaxValue);

                if (sliderValue != this.Value)
                {
                    this.Value = sliderValue;
                }
            });

            return this.Value;
        }

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), base.Decimals);
        }

        protected override bool TextIsCorrect()
        {
            float value;

            if (!float.TryParse(this.text, out value))
            {
                return false;
            }

            if (value < base.MinValue)
            {
                return false;
            }

            if (value > base.MaxValue)
            {
                return false;
            }

            string[] splits = this.text.Split('.');

            if (splits.Length == 1)
            {
                return true;
            }

            if (splits[1].Length <= base.Decimals)
            {
                return true;
            }

            return false;
        }

        #endregion Method
    }
}