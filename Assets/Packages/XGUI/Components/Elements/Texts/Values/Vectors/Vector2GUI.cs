using UnityEngine;

namespace XGUI
{
    public class Vector2GUI : VectorFloatGUI<Vector2>
    {
        #region Field

        private readonly FloatGUI _guiX = new () { Title = "X" };
        private readonly FloatGUI _guiY = new () { Title = "Y" };

        #endregion Field

        #region Property

        public override Vector2 MinValue
        {
            get => new ()
            {
                x = _guiX.MinValue,
                y = _guiY.MinValue
            };
            set
            {
                _guiX.MinValue = value.x;
                _guiY.MinValue = value.y;
            }
        }

        public override Vector2 MaxValue
        {
            get => new ()
            {
                x = _guiX.MaxValue,
                y = _guiY.MaxValue
            };
            set
            {
                _guiX.MaxValue = value.x;
                _guiY.MaxValue = value.y;
            }
        }

        public override int Digits
        {
            get => _guiX.Digits;
            set
            {
                _guiX.Digits = value;
                _guiY.Digits = value;
            }
        }

        public override float Width
        {
            get => _guiX.Width;
            set
            {
                _guiX.Width = value;
                _guiY.Width = value;
            }
        }

        public override bool Slider
        {
            get => _guiX.Slider;
            set
            {
                _guiX.Slider = value;
                _guiY.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector2GUI() { }

        public Vector2GUI(string title) : base(title) { }

        public Vector2GUI(string title, Vector2 min, Vector2 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueVector2;
            MaxValue = XGUILayout.DefaultMaxValueVector2;
        }

        protected override Vector2 ShowComponents(Vector2 value)
        {
            return new Vector2()
            {
                x = _guiX.Show(value.x),
                y = _guiY.Show(value.y)
            };
        }

        #endregion Method
    }
}