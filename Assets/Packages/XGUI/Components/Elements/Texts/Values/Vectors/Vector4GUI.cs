using UnityEngine;

namespace XGUI
{
    public class Vector4GUI : VectorFloatGUI<Vector4>
    {
        #region Field

        private readonly FloatGUI _guiX = new () { Title = "X" };
        private readonly FloatGUI _guiY = new () { Title = "Y" };
        private readonly FloatGUI _guiZ = new () { Title = "Z" };
        private readonly FloatGUI _guiW = new () { Title = "W" };

        #endregion Field

        #region Property

        public override Vector4 MinValue
        {
            get => new ()
            {
                x = _guiX.MinValue,
                y = _guiY.MinValue,
                z = _guiZ.MinValue,
                w = _guiW.MinValue
            };
            set
            {
                _guiX.MinValue = value.x;
                _guiY.MinValue = value.y;
                _guiZ.MinValue = value.z;
                _guiW.MinValue = value.w;
            }
        }

        public override Vector4 MaxValue
        {
            get => new ()
            {
                x = _guiX.MaxValue,
                y = _guiY.MaxValue,
                z = _guiZ.MaxValue,
                w = _guiW.MaxValue
            };
            set
            {
                _guiX.MaxValue = value.x;
                _guiY.MaxValue = value.y;
                _guiZ.MaxValue = value.z;
                _guiW.MaxValue = value.w;
            }
        }

        public override int Digits
        {
            get => _guiX.Digits;
            set
            {
                _guiX.Digits = value;
                _guiY.Digits = value;
                _guiZ.Digits = value;
                _guiW.Digits = value;
            }
        }

        public override float Width
        {
            get => _guiX.Width;
            set
            {
                _guiX.Width = value;
                _guiY.Width = value;
                _guiZ.Width = value;
                _guiW.Width = value;
            }
        }

        public override bool Slider
        {
            get => _guiX.Slider;
            set
            {
                _guiX.Slider = value;
                _guiY.Slider = value;
                _guiZ.Slider = value;
                _guiW.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector4GUI() { }

        public Vector4GUI(string title) : base(title) { }

        public Vector4GUI(string title, Vector4 min, Vector4 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueVector4;
            MaxValue = XGUILayout.DefaultMaxValueVector4;
        }

        protected override Vector4 ShowComponents(Vector4 value)
        {
            return new Vector4()
            {
                x = _guiX.Show(value.x),
                y = _guiY.Show(value.y),
                z = _guiZ.Show(value.z),
                w = _guiW.Show(value.w)
            };
        }

        #endregion Method
    }
}