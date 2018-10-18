using UnityEngine;

namespace XJGUI
{
    public class Vector2GUI : VectorGUI<Vector2>
    {
        #region Field

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

                base.value = new Vector2()
                {
                    x = this.floatGUIX.Value,
                    y = this.floatGUIY.Value
                };
            }
        }

        public override Vector2 MinValue
        {
            get
            {
                return new Vector2()
                {
                    x = this.floatGUIX.MinValue,
                    y = this.floatGUIY.MinValue
                };
            }
            set
            {
                this.floatGUIX.MinValue = value.x;
                this.floatGUIY.MinValue = value.y;
            }
        }

        public override Vector2 MaxValue
        {
            get
            {
                return new Vector2()
                {
                    x = this.floatGUIX.MaxValue,
                    y = this.floatGUIY.MaxValue
                };
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
            }
        }

        public override float FieldWidth
        {
            get
            {
                return this.floatGUIX.FieldWidth;
            }
            set
            {
                this.floatGUIX.FieldWidth = value;
                this.floatGUIY.FieldWidth = value;
            }
        }

        public override bool WithSlider
        {
            get
            {
                return this.floatGUIX.WithSlider;
            }

            set
            {
                this.floatGUIX.WithSlider = value;
                this.floatGUIY.WithSlider = value;
            }
        }

        public override int Decimals
        {
            get
            {
                return this.floatGUIX.Decimals;
            }
            set
            {
                this.floatGUIX.Decimals = value;
                this.floatGUIY.Decimals = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector2GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { Title = "X" };
            this.floatGUIY = new FloatGUI() { Title = "Y" };

            // NOTE:
            // Set min/max value first. If not, "Value" will collect with min/ max value 0.

            this.MinValue = XJGUILayout.DefaultMinValueVector2;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector2;
            this.Value = XJGUILayout.DefaultValueVector2;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            this.value.x = this.floatGUIX.Show();
            this.value.y = this.floatGUIY.Show();
        }

        #endregion Method
    }
}