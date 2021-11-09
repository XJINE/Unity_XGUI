using UnityEngine;

namespace XGUI
{
    public class ColorGUI : VectorFloatGUI<Color>
    {
        #region Field

        private readonly FloatGUI _guiR = new () { Title = "R" };
        private readonly FloatGUI _guiG = new () { Title = "G" };
        private readonly FloatGUI _guiB = new () { Title = "B" };
        private readonly FloatGUI _guiA = new () { Title = "A" };

        #endregion Field

        #region Property

        public override Color MinValue
        {
            get => new ()
            {
                r = _guiR.MinValue,
                g = _guiG.MinValue,
                b = _guiB.MinValue,
                a = _guiA.MinValue
            };

            set
            {
                _guiR.MinValue = value.r;
                _guiG.MinValue = value.g;
                _guiB.MinValue = value.b;
                _guiA.MinValue = value.a;
            }
        }

        public override Color MaxValue
        {
            get => new ()
            {
                r = _guiR.MaxValue,
                g = _guiG.MaxValue,
                b = _guiB.MaxValue,
                a = _guiA.MaxValue
            };

            set
            {
                _guiR.MaxValue = value.r;
                _guiG.MaxValue = value.g;
                _guiB.MaxValue = value.b;
                _guiA.MaxValue = value.a;
            }
        }

        public override int Digits
        {
            get => _guiR.Digits;
            set
            {
                _guiR.Digits = value;
                _guiG.Digits = value;
                _guiB.Digits = value;
                _guiA.Digits = value;
            }
        }

        public override float Width
        {
            get => _guiR.Width;
            set
            {
                _guiR.Width = value;
                _guiG.Width = value;
                _guiB.Width = value;
                _guiA.Width = value;
            }
        }

        public override bool Slider
        {
            get => _guiR.Slider;
            set
            {
                _guiR.Slider = value;
                _guiG.Slider = value;
                _guiB.Slider = value;
                _guiA.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public ColorGUI() { }

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
                r = _guiR.Show(value.r),
                g = _guiG.Show(value.g),
                b = _guiB.Show(value.b),
                a = _guiA.Show(value.a)
            };
        }

        #endregion Method
    }
}