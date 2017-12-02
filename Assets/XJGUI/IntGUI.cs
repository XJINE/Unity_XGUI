using UnityEngine;

namespace XJGUI
{
    public class IntGUI : AbstractGUI <int>
    {
        #region Field

        public int minValue = int.MinValue;
        public int maxValue = int.MaxValue;

        public int textFieldWidth = -1;
        public bool withSlider = true;

        private string text = null;
        private bool textIsValid = true;

        #endregion Field

        #region Property

        public override int Value
        {
            set
            {
                base.value = value;
                this.text  = value.ToString();
            }
            get
            {
                return base.value;
            }
        }

        #endregion Property

        #region Method

        public override int Show()
        {
            XJGUILayout.VerticalLayout(()=>
            {
                // TextField

                int newValue = 0;

                XJGUILayout.HorizontalLayout(() =>
                {
                    base.ShowTitle();

                    this.text = this.text == null ? base.value.ToString() : this.text;
                    this.text = GUILayout.TextField(this.text, this.textFieldWidth <= 0 ?
                                GUILayout.ExpandWidth(true) : GUILayout.Width(this.textFieldWidth));

                    this.textIsValid = int.TryParse(this.text, out newValue);

                    if (this.textIsValid)
                    {
                        this.Value = newValue;
                    }
                });

                // Slider

                if (!this.withSlider)
                {
                    return;
                }

                // NOTE:
                // If invalid value set in TextField,
                // change value only when slider value is changed.

                newValue = (int)GUILayout.HorizontalSlider(this.Value, this.minValue, this.maxValue);

                if (this.textIsValid)
                {
                    this.Value = newValue;
                }
                else
                {
                    if (base.value != newValue)
                    {
                        this.Value = newValue;
                    }
                }
            });

            return this.Value;
        }

        #endregion Method
    }
}