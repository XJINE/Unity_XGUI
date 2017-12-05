using UnityEngine;

namespace XJGUI
{
    public class IntGUI : ValueGUI<int>
    {
        #region Field

        protected string text = null;

        #endregion Field

        #region Property

        public override int Value
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

        public IntGUI() : base()
        {
            this.value = 0;
            base.minValue = int.MinValue;
            base.maxValue = int.MaxValue;
        }

        #endregion Constructor

        #region Method

        public override int Show()
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
                    // For example, int.TryParse("0.") return true.
                    // But need to keep user input text, because the user may input "0.x~" or anyother.

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

        protected int CorrectValue(int value)
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