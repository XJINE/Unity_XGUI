using UnityEngine;

namespace XJGUI
{
    public class IntGUI : NumericGUI<int>
    {
        #region Property

        public override int Decimals
        {
            get
            {
                return base.decimals;
            }
            set
            {
                base.decimals = 0;
            }
        }

        #endregion Property

        #region Constructor

        public IntGUI() : base()
        {
            this.Value = XJGUILayout.DefaultValueInt;
            base.minValue = XJGUILayout.DefaultMinValueInt;
            base.maxValue = XJGUILayout.DefaultMaxValueInt;
        }

        #endregion Constructor

        #region Method

        public override int Show()
        {
            InitializeGUIStyle();

            XJGUILayout.VerticalLayout(() =>
            {
                // TextField

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    this.text = GUILayout.TextField
                               (this.text, ValueGUI<int>.TextFieldStyle,
                                base.FieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                                         : GUILayout.Width(base.FieldWidth));

                    // NOTE:
                    // float.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~".

                    int textFieldValue;

                    if (int.TryParse(this.text, out textFieldValue))
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

                int sliderValue = (int)GUILayout.HorizontalSlider(this.Value, base.MinValue, base.MaxValue);

                if (sliderValue != this.Value)
                {
                    this.Value = sliderValue;
                }
            });

            return this.Value;
        }

        #endregion Method
    }
}