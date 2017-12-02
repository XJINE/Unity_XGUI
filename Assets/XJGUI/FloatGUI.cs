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
                base.text = value.ToString();
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

        // NOTE:
        // float.TryParse("0.") return true.
        // But need to keep user input check, because the user may input "0.x~".

        public override float Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                // TextField

                float newValue = 0;

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    base.text = base.text == null ? base.value.ToString() : base.text;
                    base.text = GUILayout.TextField(base.text, base.textFieldWidth <= 0 ?
                                GUILayout.ExpandWidth(true) : GUILayout.Width(base.textFieldWidth));

                    base.textIsValid = float.TryParse(base.text, out newValue);

                    if (base.textIsValid)
                    {
                        newValue = (float)System.Math.Round(newValue, base.decimalPlaces);
                        base.value = newValue;
                    }
                });

                // Slider

                if (!base.withSlider)
                {
                    return;
                }

                // NOTE:
                // If invalid value set in TextField,
                // change value only when slider value is changed.

                newValue = GUILayout.HorizontalSlider(this.Value, base.minValue, base.maxValue);

                if (base.textIsValid)
                {
                    base.value = newValue;
                    //this.Value = newValue;
                }
                else
                {
                    if (this.Value != newValue)
                    {
                        this.Value = newValue;
                    }
                }
            });

            return base.Value;
        }

        #endregion Method
    }
}