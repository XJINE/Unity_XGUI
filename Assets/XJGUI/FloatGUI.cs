using UnityEngine;

namespace XJGUI
{
    public class FloatGUI : FloatingPointValueGUI<float>
    {
        #region Field

        protected string text = null;

        #endregion Field

        #region Property

        public override float Value
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

        public FloatGUI() : base()
        {
            this.Value = 0;
            base.MinValue = float.MinValue;
            base.MaxValue = float.MaxValue;
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
                    // For example, float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~" or anyother.

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

                float sliderValue = GUILayout.HorizontalSlider(this.Value, base.MinValue, base.MaxValue);

                if (sliderValue != this.Value)
                {
                    this.Value = sliderValue;
                }
            });

            return this.Value;
        }

        protected float CorrectValue(float value)
        {
            if (0 < value.CompareTo(base.MaxValue))
            {
                value = base.MaxValue;
            }

            if (value.CompareTo(base.MinValue) < 0)
            {
                value = base.MinValue;
            }

            return (float)System.Math.Round(value, base.Decimals);
        }

        #endregion Method
    }
}