using UnityEngine;

namespace XJGUI
{
    public class Vector3GUI : VectorFloatGUI<Vector3>
    {
        #region Field

        private readonly FloatGUI floatGUIX = new FloatGUI() { Title = "X" };
        private readonly FloatGUI floatGUIY = new FloatGUI() { Title = "Y" };
        private readonly FloatGUI floatGUIZ = new FloatGUI() { Title = "Z" };

        #endregion Field

        #region Property

        public override Vector3 Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                this.floatGUIX.Value = value.x;
                this.floatGUIY.Value = value.y;
                this.floatGUIZ.Value = value.z;

                base.Value = new Vector3()
                {
                    x = this.floatGUIX.Value,
                    y = this.floatGUIY.Value,
                    z = this.floatGUIZ.Value
                };
            }
        }

        public override Vector3 MinValue
        {
            get
            {
                return new Vector3()
                {
                    x = this.floatGUIX.MinValue,
                    y = this.floatGUIY.MinValue,
                    z = this.floatGUIZ.MinValue
                };
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
                return new Vector3()
                {
                    x = this.floatGUIX.MaxValue,
                    y = this.floatGUIY.MaxValue,
                    z = this.floatGUIZ.MaxValue
                };
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
                this.floatGUIZ.MaxValue = value.z;
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

        #endregion Property

        #region Constructor

        public Vector3GUI() : base() { }

        public Vector3GUI(string title) : base(title) { }

        public Vector3GUI(string title, Vector3 value) : base(title, value) { }

        public Vector3GUI(string title, Vector3 value, Vector3 min, Vector3 max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueVector3;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector3;
            this.Value    = XJGUILayout.DefaultValueVector3;
        }

        protected override void ShowComponents()
        {
            this.Value = new Vector3()
            {
                x = this.floatGUIX.Show(),
                y = this.floatGUIY.Show(),
                z = this.floatGUIZ.Show()
            };
        }

        #endregion Method
    }
}