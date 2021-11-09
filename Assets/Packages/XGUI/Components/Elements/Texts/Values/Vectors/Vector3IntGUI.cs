using UnityEngine;

namespace XGUI
{
    public class Vector3IntGUI : VectorGUI<Vector3Int>
    {
        #region Field

        private readonly IntGUI intGUIX = new IntGUI() { Title = "X" };
        private readonly IntGUI intGUIY = new IntGUI() { Title = "Y" };
        private readonly IntGUI intGUIZ = new IntGUI() { Title = "Z" };

        #endregion Field

        #region Property

        public override Vector3Int MinValue
        {
            get
            {
                return new Vector3Int()
                {
                    x = this.intGUIX.MinValue,
                    y = this.intGUIY.MinValue,
                    z = this.intGUIZ.MinValue
                };
            }
            set
            {
                this.intGUIX.MinValue = value.x;
                this.intGUIY.MinValue = value.y;
                this.intGUIZ.MinValue = value.z;
            }
        }

        public override Vector3Int MaxValue
        {
            get
            {
                return new Vector3Int()
                {
                    x = this.intGUIX.MaxValue,
                    y = this.intGUIY.MaxValue,
                    z = this.intGUIZ.MaxValue
                };
            }
            set
            {
                this.intGUIX.MaxValue = value.x;
                this.intGUIY.MaxValue = value.y;
                this.intGUIZ.MaxValue = value.z;
            }
        }

        public override float Width
        {
            get
            {
                return this.intGUIX.Width;
            }
            set
            {
                this.intGUIX.Width = value;
                this.intGUIY.Width = value;
                this.intGUIZ.Width = value;
            }
        }

        public override bool Slider
        {
            get
            {
                return this.intGUIX.Slider;
            }
            set
            {
                this.intGUIX.Slider = value;
                this.intGUIY.Slider = value;
                this.intGUIZ.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector3IntGUI() : base() { }

        public Vector3IntGUI(string title) : base(title) { }

        public Vector3IntGUI(string title, Vector3Int min, Vector3Int max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XGUILayout.DefaultMinValueVector3Int;
            this.MaxValue = XGUILayout.DefaultMaxValueVector3Int;
        }

        protected override Vector3Int ShowComponents(Vector3Int value)
        {
            return new Vector3Int()
            {
                x = this.intGUIX.Show(value.x),
                y = this.intGUIY.Show(value.y),
                z = this.intGUIZ.Show(value.z)
            };
        }

        #endregion Method
    }
}