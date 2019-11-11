using UnityEngine;

namespace XGUI
{
    public class ColorGUI : VectorFloatGUI<Color>
    {
        #region Field

        private readonly FloatGUI floatGUIR = new FloatGUI() { Title = "R" };
        private readonly FloatGUI floatGUIG = new FloatGUI() { Title = "G" };
        private readonly FloatGUI floatGUIB = new FloatGUI() { Title = "B" };
        private readonly FloatGUI floatGUIA = new FloatGUI() { Title = "A" };

        #endregion Field

        #region Property

        public override Color MinValue
        {
            get
            {
                return new Color()
                {
                    r = this.floatGUIR.MinValue,
                    g = this.floatGUIG.MinValue,
                    b = this.floatGUIB.MinValue,
                    a = this.floatGUIA.MinValue
                };
            }
            set
            {
                this.floatGUIR.MinValue = value.r;
                this.floatGUIG.MinValue = value.g;
                this.floatGUIB.MinValue = value.b;
                this.floatGUIA.MinValue = value.a;
            }
        }

        public override Color MaxValue
        {
            get
            {
                return new Color()
                {
                    r = this.floatGUIR.MaxValue,
                    g = this.floatGUIG.MaxValue,
                    b = this.floatGUIB.MaxValue,
                    a = this.floatGUIA.MaxValue
                };
            }
            set
            {
                this.floatGUIR.MaxValue = value.r;
                this.floatGUIG.MaxValue = value.g;
                this.floatGUIB.MaxValue = value.b;
                this.floatGUIA.MaxValue = value.a;
            }
        }

        public override int Decimals
        {
            get
            {
                return this.floatGUIR.Decimals;
            }
            set
            {
                this.floatGUIR.Decimals = value;
                this.floatGUIG.Decimals = value;
                this.floatGUIB.Decimals = value;
                this.floatGUIA.Decimals = value;
            }
        }

        public override float Width
        {
            get
            {
                return this.floatGUIR.Width;
            }
            set
            {
                this.floatGUIR.Width = value;
                this.floatGUIG.Width = value;
                this.floatGUIB.Width = value;
                this.floatGUIA.Width = value;
            }
        }

        public override bool Slider
        {
            get
            {
                return this.floatGUIR.Slider;
            }

            set
            {
                this.floatGUIR.Slider = value;
                this.floatGUIG.Slider = value;
                this.floatGUIB.Slider = value;
                this.floatGUIA.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public ColorGUI() : base() { }

        public ColorGUI(string title) : base(title) { }

        public ColorGUI(string title, Color min, Color max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XGUILayout.DefaultMinValueColor;
            this.MaxValue = XGUILayout.DefaultMaxValueColor;
        }

        protected override Color ShowComponents(Color value)
        {
            return new Color()
            {
                r = this.floatGUIR.Show(value.r),
                g = this.floatGUIG.Show(value.g),
                b = this.floatGUIB.Show(value.b),
                a = this.floatGUIA.Show(value.a)
            };
        }

        #endregion Method
    }
}