using UnityEngine;

namespace XGUI
{
    public class Vector3IntGUI : VectorGUI<Vector3Int>
    {
        #region Field

        private readonly IntGUI _guiX = new () { Title = "X" };
        private readonly IntGUI _guiY = new () { Title = "Y" };
        private readonly IntGUI _guiZ = new () { Title = "Z" };

        #endregion Field

        #region Property

        public override Vector3Int MinValue
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

        public override Vector3Int MaxValue
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

        public Vector3IntGUI() { }

        public Vector3IntGUI(string title) : base(title) { }

        public Vector3IntGUI(string title, Vector3Int min, Vector3Int max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueVector3Int;
            MaxValue = XGUILayout.DefaultMaxValueVector3Int;
        }

        protected override Vector3Int ShowComponents(Vector3Int value)
        {
            return new Vector3Int()
            {
                x = _guiX.Show(value.x),
                y = _guiY.Show(value.y),
                z = _guiZ.Show(value.z)
            };
        }

        #endregion Method
    }
}