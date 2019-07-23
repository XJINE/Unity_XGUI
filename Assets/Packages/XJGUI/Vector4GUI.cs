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

        public Vector4GUI(string title, Vector4 min, Vector4 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueVector4;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector4;
        }

        protected override Vector4 ShowComponents(Vector4 value)
        {
            return new Vector4()
            {
                x = this.floatGUIX.Show(value.x),
                y = this.floatGUIY.Show(value.y),
                z = this.floatGUIZ.Show(value.z),
                w = this.floatGUIW.Show(value.w)
            };
        }

        #endregion Method
    }
}