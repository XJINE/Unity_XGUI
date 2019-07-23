using UnityEngine;

namespace XJGUI
{
    public class Vector2GUI : VectorFloatGUI<Vector2>
    {
        #region Field

        private readonly FloatGUI floatGUIX = new FloatGUI() { Title = "X" };
        private readonly FloatGUI floatGUIY = new FloatGUI() { Title = "Y" };

        #endregion Field

        #region Property

        public override Vector2 MinValue
        {
            get
            {
                return new Vector2()
                {
                    x = this.floatGUIX.MinValue,
                    y = this.floatGUIY.MinValue
                };
            }
            set
            {
                this.floatGUIX.MinValue = value.x;
                this.floatGUIY.MinValue = value.y;
            }
        }

        public override Vector2 MaxValue
        {
            get
            {
                return new Vector2()
                {
                    x = this.floatGUIX.MaxValue,
                    y = this.floatGUIY.MaxValue
                };
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
            }
        }

        public override int Decimals
        {
            get
            {
                return this.floatGUIX.Decimals;
            }
            set
            {
                this.floatGUIX.Decimals = value;
                this.floatGUIY.Decimals = value;
            }
        }

        public override float FieldWidth
        {
            get
            {
                return this.floatGUIX.FieldWidth;
            }
            set
            {
                this.floatGUIX.FieldWidth = value;
                this.floatGUIY.FieldWidth = value;
            }
        }

        public override bool WithSlider
        {
            get
            {
                return this.floatGUIX.WithSlider;
            }
            set
            {
                this.floatGUIX.WithSlider = value;
                this.floatGUIY.WithSlider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector2GUI() : base() { }

        public Vector2GUI(string title) : base(title) { }

        public Vector2GUI(string title, Vector2 min, Vector2 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XJGUILayout.DefaultMinValueVector2;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector2;
        }

        protected override Vector2 ShowComponents(Vector2 value)
        {
            return new Vector2()
            {
                x = this.floatGUIX.Show(value.x),
                y = this.floatGUIY.Show(value.y)
            };
        }

        #endregion Method
    }
}