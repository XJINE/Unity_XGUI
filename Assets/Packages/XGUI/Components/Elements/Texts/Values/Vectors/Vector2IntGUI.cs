using UnityEngine;

namespace XGUI
{
    public class Vector2IntGUI : VectorGUI<Vector2Int>
    {
        #region Field

        private readonly IntGUI _guiX = new () { Title = "X" };
        private readonly IntGUI _guiY = new () { Title = "Y" };

        #endregion Field

        #region Property

        public override Vector2Int MinValue
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

        public override Vector2Int MaxValue
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

        public Vector2IntGUI(){ }

        public Vector2IntGUI(string title) : base(title) { }

        public Vector2IntGUI(string title, Vector2Int min, Vector2Int max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueVector2Int;
            MaxValue = XGUILayout.DefaultMaxValueVector2Int;
        }

        protected override Vector2Int ShowComponents(Vector2Int value)
        {
            return new Vector2Int()
            {
                x = _guiX.Show(value.x),
                y = _guiY.Show(value.y)
            };
        }

        #endregion Method
    }
}