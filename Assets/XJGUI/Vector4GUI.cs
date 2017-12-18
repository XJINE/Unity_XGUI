using UnityEngine;

namespace XJGUI
{
    public class Vector4GUI : VectorGUI<Vector4>
    {
        #region Field

        private FloatGUI floatGUIX;
        private FloatGUI floatGUIY;
        private FloatGUI floatGUIZ;
        private FloatGUI floatGUIW;

        #endregion Field

        #region Property

        public override Vector4 Value
        {
            get
            {
                return base.value;
            }
            set
            {
                this.floatGUIX.Value = value.x;
                this.floatGUIY.Value = value.y;
                this.floatGUIZ.Value = value.z;
                this.floatGUIW.Value = value.w;

                base.value = new Vector4()
                {
                    x = this.floatGUIX.Value,
                    y = this.floatGUIY.Value,
                    z = this.floatGUIZ.Value,
                    w = this.floatGUIW.Value
                };
            }
        }

        public override Vector4 MinValue
        {
            get
            {
                return new Vector4()
                {
                    x = this.floatGUIX.MinValue,
                    y = this.floatGUIY.MinValue,
                    z = this.floatGUIZ.MinValue,
                    w = this.floatGUIW.MinValue
                };
            }
            set
            {
                this.floatGUIX.MinValue = value.x;
                this.floatGUIY.MinValue = value.y;
                this.floatGUIZ.MinValue = value.z;
                this.floatGUIW.MinValue = value.w;
            }
        }

        public override Vector4 MaxValue
        {
            get
            {
                return new Vector4()
                {
                    x = this.floatGUIX.MaxValue,
                    y = this.floatGUIY.MaxValue,
                    z = this.floatGUIZ.MaxValue,
                    w = this.floatGUIW.MaxValue
                };
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
                this.floatGUIZ.MaxValue = value.z;
                this.floatGUIW.MaxValue = value.w;
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
                this.floatGUIZ.FieldWidth = value;
                this.floatGUIW.FieldWidth = value;
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
                this.floatGUIZ.WithSlider = value;
                this.floatGUIW.WithSlider = value;
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
                this.floatGUIZ.Decimals = value;
                this.floatGUIW.Decimals = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector4GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { Title = "X" };
            this.floatGUIY = new FloatGUI() { Title = "Y" };
            this.floatGUIZ = new FloatGUI() { Title = "Z" };
            this.floatGUIW = new FloatGUI() { Title = "W" };

            // NOTE:
            // Set min/max value first. If not, "Value" will collect with min/ max value 0.

            this.MinValue = XJGUILayout.DefaultMinValueVector4;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector4;
            this.Value = XJGUILayout.DefaultValueVector4;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            this.value.x = this.floatGUIX.Show();
            this.value.y = this.floatGUIY.Show();
            this.value.z = this.floatGUIZ.Show();
            this.value.w = this.floatGUIW.Show();
        }

        #endregion Method
    }
}