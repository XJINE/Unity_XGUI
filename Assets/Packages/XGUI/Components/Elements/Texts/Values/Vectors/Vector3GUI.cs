using UnityEngine;

namespace XGUI
{
    public class Vector3GUI : VectorFloatGUI<Vector3>
    {
        #region Field

        private readonly FloatGUI _guiX = new () { Title = "X" };
        private readonly FloatGUI _guiY = new () { Title = "Y" };
        private readonly FloatGUI _guiZ = new () { Title = "Z" };

        #endregion Field

        #region Property

        public override Vector3 MinValue
        {
            get => new ()
            {
                x = _guiX.MinValue,
                y = _guiY.MinValue,
                z = _guiZ.MinValue
            };
            set
            {
                _guiX.MinValue = value.x;
                _guiY.MinValue = value.y;
                _guiZ.MinValue = value.z;
            }
        }

        public override Vector3 MaxValue
        {
            get => new ()
            {
                x = _guiX.MaxValue,
                y = _guiY.MaxValue,
                z = _guiZ.MaxValue
            };
            set
            {
                _guiX.MaxValue = value.x;
                _guiY.MaxValue = value.y;
                _guiZ.MaxValue = value.z;
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
            }
        }

        #endregion Property

        #region Constructor

        public Vector3GUI() { }

        public Vector3GUI(string title) : base(title) { }

        public Vector3GUI(string title, Vector3 min, Vector3 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueVector3;
            MaxValue = XGUILayout.DefaultMaxValueVector3;
        }

        protected override Vector3 ShowComponents(Vector3 value)
        {
            return new Vector3()
            {
                x = _guiX.Show(value.x),
                y = _guiY.Show(value.y),
                z = _guiZ.Show(value.z)
            };
        }

        #endregion Method
    }
}