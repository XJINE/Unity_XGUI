using UnityEngine;

namespace XJGUI
{
    public class Vector2GUI : ValueGUI<Vector2>
    {
        #region Field

        public int decimals = 2;
        public bool horizontal = true;

        private FloatGUI floatGUIX;
        private FloatGUI floatGUIY;

        #endregion Field

        #region Property

        public override Vector2 Value
        {
            get
            {
                return base.value;
            }
            set
            {
                this.floatGUIX.Value = value.x;
                this.floatGUIY.Value = value.y;
                base.value = new Vector2(this.floatGUIX.Value, this.floatGUIY.Value);
            }
        }

        #endregion Property

        #region Constructor

        public Vector2GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { title = "X" };
            this.floatGUIY = new FloatGUI() { title = "Y" };

            UpdateVector2GUI();
        }

        #endregion Constructor

        #region Method

        protected override void InitializeMinMaxValue()
        {
            this.minValue = new Vector2(float.MinValue, float.MinValue);
            this.maxValue = new Vector2(float.MaxValue, float.MaxValue);
        }

        public override Vector2 Show()
        {
            //UpdateVector2GUI();

            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                if (this.horizontal)
                {
                    XJGUILayout.HorizontalLayout(() =>
                    {
                        this.floatGUIX.Show();
                        this.floatGUIY.Show();
                    });
                }
                else
                {
                    this.floatGUIX.Show();
                    this.floatGUIY.Show();
                }
            });

            return base.Value;
        }

        public void UpdateVector2GUI()
        {
            this.floatGUIX.minValue = this.minValue.x;
            this.floatGUIX.maxValue = this.maxValue.x;
            this.floatGUIX.textFieldWidth = this.textFieldWidth;
            this.floatGUIX.withSlider = this.withSlider;
            this.floatGUIX.decimals   = this.decimals;

            this.floatGUIY.minValue = this.minValue.y;
            this.floatGUIY.maxValue = this.maxValue.y;
            this.floatGUIY.textFieldWidth = this.textFieldWidth;
            this.floatGUIY.withSlider = this.withSlider;
            this.floatGUIY.decimals = this.decimals;
        }

        #endregion Method
    }
}