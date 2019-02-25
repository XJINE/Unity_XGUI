using UnityEngine;

namespace XJGUI
{
    public class Vector3IntGUI : VectorGUI<Vector3Int>
    {
        #region Field

        private readonly IntGUI intGUIX = new IntGUI() { Title = "X" };
        private readonly IntGUI intGUIY = new IntGUI() { Title = "Y" };
        private readonly IntGUI intGUIZ = new IntGUI() { Title = "Z" };

        #endregion Field

        #region Property

        public override Vector3Int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                this.intGUIX.Value = value.x;
                this.intGUIY.Value = value.y;
                this.intGUIZ.Value = value.z;

                base.Value = new Vector3Int()
                {
                    x = this.intGUIX.Value,
                    y = this.intGUIY.Value,
                    z = this.intGUIZ.Value
                };
            }
        }

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

        public override float FieldWidth
        {
            get
            {
                return this.intGUIX.FieldWidth;
            }
            set
            {
                this.intGUIX.FieldWidth = value;
                this.intGUIY.FieldWidth = value;
                this.intGUIZ.FieldWidth = value;
            }
        }

        public override bool WithSlider
        {
            get
            {
                return this.intGUIX.WithSlider;
            }
            set
            {
                this.intGUIX.WithSlider = value;
                this.intGUIY.WithSlider = value;
                this.intGUIZ.WithSlider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector3IntGUI() : base() { }

        public Vector3IntGUI(string title) : base(title) { }

        public Vector3IntGUI(string title, Vector3Int value) : base(title, value) { }

        public Vector3IntGUI(string title, Vector3Int value, Vector3Int min, Vector3Int max) : base(title, value, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueVector3Int;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector3Int;
            this.Value    = XJGUILayout.DefaultValueVector3Int;
        }

        protected override void ShowComponents()
        {
            this.Value = new Vector3Int()
            {
                x = this.intGUIX.Show(),
                y = this.intGUIY.Show(),
                z = this.intGUIZ.Show()
            };
        }

        #endregion Method
    }
}