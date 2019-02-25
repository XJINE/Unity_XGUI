using UnityEngine;

namespace XJGUI
{
    public class Vector4GUI : VectorFloatGUI<Vector4>
    {
        #region Field

        private readonly FloatGUI floatGUIX = new FloatGUI() { Title = "X" };
        private readonly FloatGUI floatGUIY = new FloatGUI() { Title = "Y" };
        private readonly FloatGUI floatGUIZ = new FloatGUI() { Title = "Z" };
        private readonly FloatGUI floatGUIW = new FloatGUI() { Title = "W" };

        #endregion Field

        #region Property

        public override Vector4 Value
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
                this.floatGUIW.Value = value.w;

                base.Value = new Vector4()
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

        #endregion Property

        #region Constructor

        public Vector4GUI() : base() { }

        public Vector4GUI(string title) : base(title) { }

        public Vector4GUI(string title, Vector4 value) : base(title, value) { }

        public Vector4GUI(string title, Vector4 value, Vector4 min, Vector4 max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueVector4;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector4;
            this.Value    = XJGUILayout.DefaultValueVector4;
        }

        protected override void ShowComponents()
        {
            this.Value = new Vector4()
            {
                x = this.floatGUIX.Show(),
                y = this.floatGUIY.Show(),
                z = this.floatGUIZ.Show(),
                w = this.floatGUIW.Show()
            };
        }

        #endregion Method
    }
}