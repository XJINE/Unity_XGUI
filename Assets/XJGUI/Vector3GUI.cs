using UnityEngine;

namespace XJGUI
{
    public class Vector3GUI : VectorGUI<Vector3>
    {
        #region Field

        private FloatGUI floatGUIX;
        private FloatGUI floatGUIY;
        private FloatGUI floatGUIZ;

        #endregion Field

        #region Property

        public override Vector3 Value
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

                base.value = new Vector3(this.floatGUIX.Value,
                                         this.floatGUIY.Value,
                                         this.floatGUIZ.Value);
            }
        }

        public override Vector3 MinValue
        {
            get
            {
                return new Vector3(this.floatGUIX.MinValue,
                                   this.floatGUIY.MinValue,
                                   this.floatGUIZ.MinValue);
            }
            set
            {
                this.floatGUIX.MinValue = value.x;
                this.floatGUIY.MinValue = value.y;
                this.floatGUIZ.MinValue = value.z;
            }
        }

        public override Vector3 MaxValue
        {
            get
            {
                return new Vector3(this.floatGUIX.MaxValue,
                                   this.floatGUIY.MaxValue,
                                   this.floatGUIZ.MaxValue);
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
                this.floatGUIZ.MaxValue = value.z;
            }
        }

        public override float TextFieldWidth
        {
            get
            {
                return this.floatGUIX.TextFieldWidth;
            }
            set
            {
                this.floatGUIX.TextFieldWidth = value;
                this.floatGUIY.TextFieldWidth = value;
                this.floatGUIZ.TextFieldWidth = value;
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
            }
        }

        #endregion Property

        #region Constructor

        public Vector3GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { Title = "X" };
            this.floatGUIY = new FloatGUI() { Title = "Y" };
            this.floatGUIZ = new FloatGUI() { Title = "Z" };

            this.MinValue = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            this.MaxValue = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            this.TextFieldWidth = -1;
            this.WithSlider = true;
            this.Decimals = 2;
            base.Horizontal = true;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            this.value.x = this.floatGUIX.Show();
            this.value.y = this.floatGUIY.Show();
            this.value.z = this.floatGUIZ.Show();
        }

        #endregion Method
    }
}