using UnityEngine;

namespace XJGUI
{
    public class ColorGUI : VectorGUI<Color>
    {
        #region Field

        private static GUIStyle ColorStyle;
        private Texture2D backgroundTexture;

        private FloatGUI floatGUIR;
        private FloatGUI floatGUIG;
        private FloatGUI floatGUIB;
        private FloatGUI floatGUIA;

        protected bool hsvMode;

        #endregion Field

        #region Property

        public override Color Value
        {
            get
            {
                return base.value;
            }
            set
            {
                this.floatGUIR.Value = value.r;
                this.floatGUIG.Value = value.g;
                this.floatGUIB.Value = value.b;
                this.floatGUIA.Value = value.a;

                base.value = new Color()
                {
                    r = this.floatGUIR.Value,
                    g = this.floatGUIG.Value,
                    b = this.floatGUIB.Value,
                    a = this.floatGUIA.Value
                };
            }
        }

        public override Color MinValue
        {
            get
            {
                return new Color()
                {
                    r = this.floatGUIR.MinValue,
                    g = this.floatGUIG.MinValue,
                    b = this.floatGUIB.MinValue,
                    a = this.floatGUIA.MinValue
                };
            }
            set
            {
                this.floatGUIR.MinValue = value.r;
                this.floatGUIG.MinValue = value.g;
                this.floatGUIB.MinValue = value.b;
                this.floatGUIA.MinValue = value.a;
            }
        }

        public override Color MaxValue
        {
            get
            {
                return new Vector4()
                {
                    x = this.floatGUIR.MaxValue,
                    y = this.floatGUIG.MaxValue,
                    z = this.floatGUIB.MaxValue,
                    w = this.floatGUIA.MaxValue
                };
            }
            set
            {
                this.floatGUIR.MaxValue = value.r;
                this.floatGUIG.MaxValue = value.g;
                this.floatGUIB.MaxValue = value.b;
                this.floatGUIA.MaxValue = value.a;
            }
        }

        public override float FieldWidth
        {
            get
            {
                return this.floatGUIR.FieldWidth;
            }
            set
            {
                this.floatGUIR.FieldWidth = value;
                this.floatGUIG.FieldWidth = value;
                this.floatGUIB.FieldWidth = value;
                this.floatGUIA.FieldWidth = value;
            }
        }

        public override bool WithSlider
        {
            get
            {
                return this.floatGUIR.WithSlider;
            }

            set
            {
                this.floatGUIR.WithSlider = value;
                this.floatGUIG.WithSlider = value;
                this.floatGUIB.WithSlider = value;
                this.floatGUIA.WithSlider = value;
            }
        }

        public override int Decimals
        {
            get
            {
                return this.floatGUIR.Decimals;
            }
            set
            {
                this.floatGUIR.Decimals = value;
                this.floatGUIG.Decimals = value;
                this.floatGUIB.Decimals = value;
                this.floatGUIA.Decimals = value;
            }
        }

        public virtual bool HSVMode
        {
            get
            {
                return this.hsvMode;
            }
            set
            {
                this.hsvMode = true;

                this.floatGUIR.Title = "H";
                this.floatGUIG.Title = "S";
                this.floatGUIB.Title = "V";
                this.floatGUIA.Title = "A";

                float h, s, v;
                float a = this.Value.a;
                Color.RGBToHSV(this.Value, out h, out s, out v);

                this.Value = new Color(h, s, v, a);
            }
        }

        #endregion Property

        #region Constructor

        public ColorGUI() : base()
        {
            this.floatGUIR = new FloatGUI() { Title = "R" };
            this.floatGUIG = new FloatGUI() { Title = "G" };
            this.floatGUIB = new FloatGUI() { Title = "B" };
            this.floatGUIA = new FloatGUI() { Title = "A" };

            this.backgroundTexture = XJGUILayout.Generate1x1Texture(this.Value);

            // NOTE:
            // Use Property to update each FloatGUI.

            this.MinValue = XJGUILayout.DefaultMinValueColor;
            this.MaxValue = XJGUILayout.DefaultMaxValueColor;

            this.hsvMode = XJGUILayout.DefaultHSVMode;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            if (ColorGUI.ColorStyle == null)
            {
                ColorGUI.ColorStyle = new GUIStyle(GUI.skin.label);
            }

            Color backgroundColor = this.HSVMode ? Color.HSVToRGB
                (this.Value.r, this.Value.g, this.Value.b) : this.Value;

            backgroundColor.a = 1;

            XJGUILayout.SetColorTo1x1Texture(this.backgroundTexture, backgroundColor);

            ColorGUI.ColorStyle.normal.background = this.backgroundTexture;

            GUILayout.Label("     ", ColorGUI.ColorStyle);

            base.value.r = this.floatGUIR.Show();
            base.value.g = this.floatGUIG.Show();
            this.value.b = this.floatGUIB.Show();
            this.value.a = this.floatGUIA.Show();
        }

        #endregion Method
    }
}