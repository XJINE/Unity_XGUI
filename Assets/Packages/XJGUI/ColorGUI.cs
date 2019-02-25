using UnityEngine;

namespace XJGUI
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

        public override Color Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                this.floatGUIR.Value = value.r;
                this.floatGUIG.Value = value.g;
                this.floatGUIB.Value = value.b;
                this.floatGUIA.Value = value.a;

                base.Value = new Color()
                {
                    r = this.floatGUIR.Value,
                    g = this.floatGUIG.Value,
                    b = this.floatGUIB.Value,
                    a = this.floatGUIA.Value
                };
            }
        }

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

        public override float FieldWidth
        {
            get
            {
                return this.floatGUIR.FieldWidth;
            }
            set
            {
                this.floatGUIR.FieldWidth = value;
                this.floatGUIG.FieldWidth = value;
                this.floatGUIB.FieldWidth = value;
                this.floatGUIA.FieldWidth = value;
            }
        }

        public override bool WithSlider
        {
            get
            {
                return this.floatGUIR.WithSlider;
            }

            set
            {
                this.floatGUIR.WithSlider = value;
                this.floatGUIG.WithSlider = value;
                this.floatGUIB.WithSlider = value;
                this.floatGUIA.WithSlider = value;
            }
        }

        #endregion Property

        #region Constructor

        public ColorGUI() : base() { }

        public ColorGUI(string title) : base(title) { }

        public ColorGUI(string title, Color value) : base(title, value) { }

        public ColorGUI(string title, Color value, Color min, Color max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueColor;
            this.MaxValue = XJGUILayout.DefaultMaxValueColor;
            this.Value    = XJGUILayout.DefaultValueColor;
        }

        protected override void ShowComponents()
        {
            this.Value = new Color()
            {
                r = this.floatGUIR.Show(),
                g = this.floatGUIG.Show(),
                b = this.floatGUIB.Show(),
                a = this.floatGUIA.Show()
            };
        }

        #endregion Method
    }
}