using UnityEngine;

namespace XGUI
{
    public class Matrix4x4GUI : ValueGUI<Matrix4x4>
    {
        #region Field

        private readonly FoldoutPanel foldoutPanel = new FoldoutPanel();

        private readonly FloatGUI floatGUIM00 = new FloatGUI() { Title = "M00" };
        private readonly FloatGUI floatGUIM10 = new FloatGUI() { Title = "M10" };
        private readonly FloatGUI floatGUIM20 = new FloatGUI() { Title = "M20" };
        private readonly FloatGUI floatGUIM30 = new FloatGUI() { Title = "M30" };

        private readonly FloatGUI floatGUIM01 = new FloatGUI() { Title = "M01" };
        private readonly FloatGUI floatGUIM11 = new FloatGUI() { Title = "M11" };
        private readonly FloatGUI floatGUIM21 = new FloatGUI() { Title = "M21" };
        private readonly FloatGUI floatGUIM31 = new FloatGUI() { Title = "M31" };

        private readonly FloatGUI floatGUIM02 = new FloatGUI() { Title = "M02" };
        private readonly FloatGUI floatGUIM12 = new FloatGUI() { Title = "M12" };
        private readonly FloatGUI floatGUIM22 = new FloatGUI() { Title = "M22" };
        private readonly FloatGUI floatGUIM32 = new FloatGUI() { Title = "M32" };

        private readonly FloatGUI floatGUIM03 = new FloatGUI() { Title = "M03" };
        private readonly FloatGUI floatGUIM13 = new FloatGUI() { Title = "M13" };
        private readonly FloatGUI floatGUIM23 = new FloatGUI() { Title = "M23" };
        private readonly FloatGUI floatGUIM33 = new FloatGUI() { Title = "M33" };

        #endregion Field

        #region Property

        public override string Title
        {
            get { return this.foldoutPanel.Title;  }
            set { this.foldoutPanel.Title = value; }
        }

        public override Matrix4x4 MinValue
        {
            get
            {
                return new Matrix4x4()
                {
                    m00 = this.floatGUIM00.MinValue,
                    m10 = this.floatGUIM10.MinValue,
                    m20 = this.floatGUIM20.MinValue,
                    m30 = this.floatGUIM30.MinValue,

                    m01 = this.floatGUIM01.MinValue,
                    m11 = this.floatGUIM11.MinValue,
                    m21 = this.floatGUIM21.MinValue,
                    m31 = this.floatGUIM31.MinValue,

                    m02 = this.floatGUIM02.MinValue,
                    m12 = this.floatGUIM12.MinValue,
                    m22 = this.floatGUIM22.MinValue,
                    m32 = this.floatGUIM32.MinValue,

                    m03 = this.floatGUIM03.MinValue,
                    m13 = this.floatGUIM13.MinValue,
                    m23 = this.floatGUIM23.MinValue,
                    m33 = this.floatGUIM33.MinValue,
                };
            }
            set
            {
                this.floatGUIM00.MinValue = value.m00;
                this.floatGUIM10.MinValue = value.m10;
                this.floatGUIM20.MinValue = value.m20;
                this.floatGUIM30.MinValue = value.m30;

                this.floatGUIM01.MinValue = value.m01;
                this.floatGUIM11.MinValue = value.m11;
                this.floatGUIM21.MinValue = value.m21;
                this.floatGUIM31.MinValue = value.m31;

                this.floatGUIM02.MinValue = value.m02;
                this.floatGUIM12.MinValue = value.m12;
                this.floatGUIM22.MinValue = value.m22;
                this.floatGUIM32.MinValue = value.m32;

                this.floatGUIM03.MinValue = value.m03;
                this.floatGUIM13.MinValue = value.m13;
                this.floatGUIM23.MinValue = value.m23;
                this.floatGUIM33.MinValue = value.m33;
            }
        }

        public override Matrix4x4 MaxValue
        {
            get
            {
                return new Matrix4x4()
                {
                    m00 = this.floatGUIM00.MaxValue,
                    m10 = this.floatGUIM10.MaxValue,
                    m20 = this.floatGUIM20.MaxValue,
                    m30 = this.floatGUIM30.MaxValue,

                    m01 = this.floatGUIM01.MaxValue,
                    m11 = this.floatGUIM11.MaxValue,
                    m21 = this.floatGUIM21.MaxValue,
                    m31 = this.floatGUIM31.MaxValue,

                    m02 = this.floatGUIM02.MaxValue,
                    m12 = this.floatGUIM12.MaxValue,
                    m22 = this.floatGUIM22.MaxValue,
                    m32 = this.floatGUIM32.MaxValue,

                    m03 = this.floatGUIM03.MaxValue,
                    m13 = this.floatGUIM13.MaxValue,
                    m23 = this.floatGUIM23.MaxValue,
                    m33 = this.floatGUIM33.MaxValue,
                };
            }
            set
            {
                this.floatGUIM00.MaxValue = value.m00;
                this.floatGUIM10.MaxValue = value.m10;
                this.floatGUIM20.MaxValue = value.m20;
                this.floatGUIM30.MaxValue = value.m30;

                this.floatGUIM01.MaxValue = value.m01;
                this.floatGUIM11.MaxValue = value.m11;
                this.floatGUIM21.MaxValue = value.m21;
                this.floatGUIM31.MaxValue = value.m31;

                this.floatGUIM02.MaxValue = value.m02;
                this.floatGUIM12.MaxValue = value.m12;
                this.floatGUIM22.MaxValue = value.m22;
                this.floatGUIM32.MaxValue = value.m32;

                this.floatGUIM03.MaxValue = value.m03;
                this.floatGUIM13.MaxValue = value.m13;
                this.floatGUIM23.MaxValue = value.m23;
                this.floatGUIM33.MaxValue = value.m33;
            }
        }

        public virtual int Decimals
        {
            get
            {
                return this.floatGUIM00.Decimals;
            }
            set
            {
                this.floatGUIM00.Decimals = value;
                this.floatGUIM10.Decimals = value;
                this.floatGUIM20.Decimals = value;
                this.floatGUIM30.Decimals = value;

                this.floatGUIM01.Decimals = value;
                this.floatGUIM11.Decimals = value;
                this.floatGUIM21.Decimals = value;
                this.floatGUIM31.Decimals = value;

                this.floatGUIM02.Decimals = value;
                this.floatGUIM12.Decimals = value;
                this.floatGUIM22.Decimals = value;
                this.floatGUIM32.Decimals = value;

                this.floatGUIM03.Decimals = value;
                this.floatGUIM13.Decimals = value;
                this.floatGUIM23.Decimals = value;
                this.floatGUIM33.Decimals = value;
            }
        }

        public override float Width
        {
            get
            {
                return this.floatGUIM00.Width;
            }
            set
            {
                this.floatGUIM00.Width = value;
                this.floatGUIM10.Width = value;
                this.floatGUIM20.Width = value;
                this.floatGUIM30.Width = value;

                this.floatGUIM01.Width = value;
                this.floatGUIM11.Width = value;
                this.floatGUIM21.Width = value;
                this.floatGUIM31.Width = value;

                this.floatGUIM02.Width = value;
                this.floatGUIM12.Width = value;
                this.floatGUIM22.Width = value;
                this.floatGUIM32.Width = value;

                this.floatGUIM03.Width = value;
                this.floatGUIM13.Width = value;
                this.floatGUIM23.Width = value;
                this.floatGUIM33.Width = value;
            }
        }

        public override bool Slider
        {
            get
            {
                return this.floatGUIM00.Slider;
            }
            set
            {
                this.floatGUIM00.Slider = value;
                this.floatGUIM10.Slider = value;
                this.floatGUIM20.Slider = value;
                this.floatGUIM30.Slider = value;

                this.floatGUIM01.Slider = value;
                this.floatGUIM11.Slider = value;
                this.floatGUIM21.Slider = value;
                this.floatGUIM31.Slider = value;

                this.floatGUIM02.Slider = value;
                this.floatGUIM12.Slider = value;
                this.floatGUIM22.Slider = value;
                this.floatGUIM32.Slider = value;

                this.floatGUIM03.Slider = value;
                this.floatGUIM13.Slider = value;
                this.floatGUIM23.Slider = value;
                this.floatGUIM33.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Matrix4x4GUI() : base() { }

        public Matrix4x4GUI(string title) : base(title) { }

        public Matrix4x4GUI(string title, Matrix4x4 min, Matrix4x4 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.MinValue = XGUILayout.DefaultMinValueMatrix4x4;
            this.MaxValue = XGUILayout.DefaultMaxValueMatrix4x4;
        }

        public override Matrix4x4 Show(Matrix4x4 value)
        {
            this.foldoutPanel.Show(() =>
            {
                XGUILayout.HorizontalLayout(() =>
                {
                    value.m00 = this.floatGUIM00.Show(value.m00);
                    value.m10 = this.floatGUIM10.Show(value.m10);
                    value.m20 = this.floatGUIM20.Show(value.m20);
                    value.m30 = this.floatGUIM30.Show(value.m30);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m01 = this.floatGUIM01.Show(value.m01);
                    value.m11 = this.floatGUIM11.Show(value.m11);
                    value.m21 = this.floatGUIM21.Show(value.m21);
                    value.m31 = this.floatGUIM31.Show(value.m31);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m02 = this.floatGUIM02.Show(value.m02);
                    value.m12 = this.floatGUIM12.Show(value.m12);
                    value.m22 = this.floatGUIM22.Show(value.m22);
                    value.m32 = this.floatGUIM32.Show(value.m32);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m03 = this.floatGUIM03.Show(value.m03);
                    value.m13 = this.floatGUIM13.Show(value.m13);
                    value.m23 = this.floatGUIM23.Show(value.m23);
                    value.m33 = this.floatGUIM33.Show(value.m33);
                });
            });
            
            return value;
        }

        #endregion Method
    }
}