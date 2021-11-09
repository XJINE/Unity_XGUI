using UnityEngine;

namespace XGUI
{
    public class Vector3GUI : VectorFloatGUI<Vector3>
    {
        #region Field

        private readonly FloatGUI floatGUIX = new FloatGUI() { Title = "X" };
        private readonly FloatGUI floatGUIY = new FloatGUI() { Title = "Y" };
        private readonly FloatGUI floatGUIZ = new FloatGUI() { Title = "Z" };

        #endregion Field

        #region Property

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

        public override float Width
        {
            get
            {
                return this.floatGUIX.Width;
            }
            set
            {
                this.floatGUIX.Width = value;
                this.floatGUIY.Width = value;
                this.floatGUIZ.Width = value;
            }
        }

        public override bool Slider
        {
            get
            {
                return this.floatGUIX.Slider;
            }
            set
            {
                this.floatGUIX.Slider = value;
                this.floatGUIY.Slider = value;
                this.floatGUIZ.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector3GUI() : base() { }

        public Vector3GUI(string title) : base(title) { }

        public Vector3GUI(string title, Vector3 min, Vector3 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XGUILayout.DefaultMinValueVector3;
            this.MaxValue = XGUILayout.DefaultMaxValueVector3;
        }

        protected override Vector3 ShowComponents(Vector3 value)
        {
            return new Vector3()
            {
                x = this.floatGUIX.Show(value.x),
                y = this.floatGUIY.Show(value.y),
                z = this.floatGUIZ.Show(value.z)
            };
        }

        #endregion Method
    }
}