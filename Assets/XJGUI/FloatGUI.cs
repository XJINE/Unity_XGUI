using UnityEngine;

namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Constructor

        public FloatGUI() : base()
        {
            this.Value = 0;
            base.minValue = float.MinValue;
            base.maxValue = float.MaxValue;
        }

        #endregion Constructor

        #region Method

        public override float Show()
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

        #endregion Method
    }
}