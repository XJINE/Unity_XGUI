using UnityEngine;

namespace XJGUI
{
    public class FloatGUI : FloatingValueGUI<float>
    {
        #region Property

        public override float Value
        {
            set
            {
                base.value = (float)System.Math.Round(value, base.decimalPlaces);
                base.text = base.value.ToString();
            }
            get
            {
                return base.value;
            }
        }

        #endregion Property

        #region Method

        protected override void InitializeMinMaxValue()
        {
            base.minValue = float.MinValue;
            base.maxValue = float.MaxValue;
        }

        public override float Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                // TextField

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    base.text = GUILayout.TextField(base.text, base.textFieldWidth <= 0 ?
                                GUILayout.ExpandWidth(true) : GUILayout.Width(base.textFieldWidth));

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    float textFieldValue;

                    if (float.TryParse(base.text, out textFieldValue))
                    {
                        base.value = (float)System.Math.Round(textFieldValue, base.decimalPlaces);
                    }
                });

                // Slider

                if (!base.withSlider)
                {
                    return;
                }

                // NOTE:
                // Need to update text when the value is updated with Slider.

                float sliderValue = GUILayout.HorizontalSlider(base.value, base.minValue, base.maxValue);

                if (sliderValue != base.value)
                {
                    this.Value = sliderValue;
                }
            });

            return base.Value;
        }

        #endregion Method
    }
}