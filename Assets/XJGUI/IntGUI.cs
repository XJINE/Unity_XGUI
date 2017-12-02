using UnityEngine;

namespace XJGUI
{
    public class IntGUI : ValueGUI <int>
    {
        #region Property

        public override int Value
        {
            set
            {
                base.value = value;
                base.text  = value.ToString();
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
            base.minValue = int.MinValue;
            base.maxValue = int.MaxValue;
        }

        public override int Show()
        {
            XJGUILayout.VerticalLayout(()=>
            {
                // NOTE:
                // To Update text, need to use not base.value but this.Value.

                // TextField

                int newValue = 0;

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    base.text = GUILayout.TextField(base.text, base.textFieldWidth <= 0 ?
                                GUILayout.ExpandWidth(true) : GUILayout.Width(base.textFieldWidth));

                    base.textIsValid = int.TryParse(base.text, out newValue);

                    if (base.textIsValid)
                    {
                        this.Value = newValue;
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

                newValue = (int)GUILayout.HorizontalSlider(this.Value, base.minValue, base.maxValue);

                if (base.textIsValid)
                {
                    this.Value = newValue;
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