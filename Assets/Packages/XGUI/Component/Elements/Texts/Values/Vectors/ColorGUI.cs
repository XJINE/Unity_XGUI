using UnityEngine;

namespace XGUI
{
    public class ColorGUI : VectorFloatGUI<Color>
    {
        #region Field

        private readonly FloatGUI floatGUIR = new () { Title = "R" };
        private readonly FloatGUI floatGUIG = new () { Title = "G" };
        private readonly FloatGUI floatGUIB = new () { Title = "B" };
        private readonly FloatGUI floatGUIA = new () { Title = "A" };

        #endregion Field

        #region Property

        public override Color MinValue
        {
            get => new ()
            {
                r = floatGUIR.MinValue,
                g = floatGUIG.MinValue,
                b = floatGUIB.MinValue,
                a = floatGUIA.MinValue
            };

            set
            {
                floatGUIR.MinValue = value.r;
                floatGUIG.MinValue = value.g;
                floatGUIB.MinValue = value.b;
                floatGUIA.MinValue = value.a;
            }
        }

        public override Color MaxValue
        {
            get => new()
            {
                r = floatGUIR.MaxValue,
                g = floatGUIG.MaxValue,
                b = floatGUIB.MaxValue,
                a = floatGUIA.MaxValue
            };

            set
            {
                floatGUIR.MaxValue = value.r;
                floatGUIG.MaxValue = value.g;
                floatGUIB.MaxValue = value.b;
                floatGUIA.MaxValue = value.a;
            }
        }

        public override int Decimals
        {
            get => floatGUIR.Digits;
            set
            {
                floatGUIR.Digits = value;
                floatGUIG.Digits = value;
                floatGUIB.Digits = value;
                floatGUIA.Digits = value;
            }
        }

        public override float Width
        {
            get => floatGUIR.Width;
            set
            {
                floatGUIR.Width = value;
                floatGUIG.Width = value;
                floatGUIB.Width = value;
                floatGUIA.Width = value;
            }
        }

        public override bool Slider
        {
            get => floatGUIR.Slider;
            set
            {
                floatGUIR.Slider = value;
                floatGUIG.Slider = value;
                floatGUIB.Slider = value;
                floatGUIA.Slider = value;
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

            MinValue = XGUILayout.DefaultMinValueColor;
            MaxValue = XGUILayout.DefaultMaxValueColor;
        }

        protected override Color ShowComponents(Color value)
        {
            return new Color()
            {
                r = floatGUIR.Show(value.r),
                g = floatGUIG.Show(value.g),
                b = floatGUIB.Show(value.b),
                a = floatGUIA.Show(value.a)
            };
        }

        #endregion Method
    }
}