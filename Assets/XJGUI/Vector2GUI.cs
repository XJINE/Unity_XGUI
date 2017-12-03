using UnityEngine;

namespace XJGUI
{
    public class Vector2GUI : VectorGUI<Vector2>
    {
        #region Field

        private FloatGUI floatGUIX;
        private FloatGUI floatGUIY;

        #endregion Field

        #region Property

        public override Vector2 Value
        {
            get
            {
                return base.value;
            }
            set
            {
                this.floatGUIX.Value = value.x;
                this.floatGUIY.Value = value.y;
                base.value = new Vector2(this.floatGUIX.Value, this.floatGUIY.Value);
            }
        }

        public override Vector2 MinValue
        {
            get
            {
                return new Vector2(this.floatGUIX.MinValue, this.floatGUIY.MinValue);
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
                return new Vector2(this.floatGUIX.MaxValue, this.floatGUIY.MaxValue);
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
            }
        }

        public override float TextFieldWidth
        {
            get
            {
                return this.floatGUIX.TextFieldWidth;
            }
            set
            {
                this.floatGUIX.TextFieldWidth = value;
                this.floatGUIY.TextFieldWidth = value;
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

        #endregion Property

        #region Constructor

        public Vector2GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { Title = "X" };
            this.floatGUIY = new FloatGUI() { Title = "Y" };

            this.MinValue = new Vector2(float.MinValue, float.MinValue);
            this.MaxValue = new Vector2(float.MaxValue, float.MaxValue);
            this.TextFieldWidth = -1;
            this.WithSlider = true;
            this.Decimals = 2;
            base.Horizontal = true;
        }

        #endregion Constructor

        #region Method

        public override Vector2 Show()
        {
            XJGUILayout.VerticalLayout((System.Action)(() =>
            {
                base.ShowTitle();

                if (this.Horizontal)
                {
                    XJGUILayout.HorizontalLayout(() =>
                    {
                        this.floatGUIX.Show();
                        this.floatGUIY.Show();
                    });
                }
                else
                {
                    this.floatGUIX.Show();
                    this.floatGUIY.Show();
                }
            }));

            return this.Value;
        }

        #endregion Method
    }
}