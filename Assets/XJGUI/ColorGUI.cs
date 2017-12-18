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

        protected bool hsv;

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
                return new Color()
                {
                    r = this.floatGUIR.MaxValue,
                    g = this.floatGUIG.MaxValue,
                    b = this.floatGUIB.MaxValue,
                    a = this.floatGUIA.MaxValue
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

        public virtual bool HSV
        {
            get
            {
                return this.hsv;
            }
            set
            {
                bool hsvPrev = this.hsv;
                this.hsv = value;

                if (this.hsv && !hsvPrev)
                {
                    this.floatGUIR.Title = "H";
                    this.floatGUIG.Title = "S";
                    this.floatGUIB.Title = "V";
                    this.floatGUIA.Title = "A";

                    float h, s, v;
                    float a = this.Value.a;
                    Color.RGBToHSV(this.Value, out h, out s, out v);
                    this.Value = new Color(h, s, v, a);
                }
                else if(!this.hsv && hsvPrev)
                {
                    this.floatGUIR.Title = "R";
                    this.floatGUIG.Title = "G";
                    this.floatGUIB.Title = "B";
                    this.floatGUIA.Title = "A";

                    Color color = Color.HSVToRGB(this.Value.r, this.Value.g, this.Value.b);
                    color.a = this.Value.a;
                    this.Value = color;
                }
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

            // NOTE:
            // Use this.Property to update each FloatGUI.

            this.Value = XJGUILayout.DefaultValueColor;
            this.MinValue = XJGUILayout.DefaultMinValueColor;
            this.MaxValue = XJGUILayout.DefaultMaxValueColor;
            this.HSV = XJGUILayout.DefaultHSV;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            if (ColorGUI.ColorStyle == null)
            {
                ColorGUI.ColorStyle = new GUIStyle(GUI.skin.label);
                ColorGUI.ColorStyle.margin = new RectOffset(ColorGUI.ColorStyle.margin.left   + 5,
                                                            ColorGUI.ColorStyle.margin.right  + 5,
                                                            ColorGUI.ColorStyle.margin.top    + 5,
                                                            ColorGUI.ColorStyle.margin.bottom + 5);
            }

            Color backgroundColor = this.hsv ? Color.HSVToRGB(base.value.r, base.value.g, base.value.b) : base.value;
            backgroundColor.a = base.value.a;

            this.backgroundTexture = UpdateBackgrondTexture(backgroundColor, this.backgroundTexture);
            ColorGUI.ColorStyle.normal.background = this.backgroundTexture;

            GUILayout.Label("     ", ColorGUI.ColorStyle);

            base.value.r = this.floatGUIR.Show();
            base.value.g = this.floatGUIG.Show();
            this.value.b = this.floatGUIB.Show();
            this.value.a = this.floatGUIA.Show();
        }

        private static Texture2D UpdateBackgrondTexture(Color color, Texture2D backgroundTexture = null)
        {
            float a = color.a;
            color = new Color(color.r, color.g, color.b, 1);

            Color[] pixels = new Color[9]
            {
                color, color, new Color(a, a, a, 1),
                color, color, color,
                color, color, color,
            };

            if (backgroundTexture == null)
            {
                backgroundTexture = new Texture2D(3, 3);
                backgroundTexture.hideFlags = HideFlags.HideAndDontSave;
                backgroundTexture.wrapMode = TextureWrapMode.Clamp;
                backgroundTexture.filterMode = FilterMode.Point;
            }

            backgroundTexture.SetPixels(pixels);
            backgroundTexture.Apply();

            return backgroundTexture;
        }

        #endregion Method
    }
}