using UnityEngine;

namespace XGUI
{
    public class Matrix4x4GUI : ValueGUI<Matrix4x4>
    {
        #region Field

        private readonly FoldoutPanel _foldoutPanel = new ();

        private readonly FloatGUI _guiM00 = new () { Title = "M00" };
        private readonly FloatGUI _guiM10 = new () { Title = "M10" };
        private readonly FloatGUI _guiM20 = new () { Title = "M20" };
        private readonly FloatGUI _guiM30 = new () { Title = "M30" };

        private readonly FloatGUI _guiM01 = new () { Title = "M01" };
        private readonly FloatGUI _guiM11 = new () { Title = "M11" };
        private readonly FloatGUI _guiM21 = new () { Title = "M21" };
        private readonly FloatGUI _guiM31 = new () { Title = "M31" };

        private readonly FloatGUI _guiM02 = new () { Title = "M02" };
        private readonly FloatGUI _guiM12 = new () { Title = "M12" };
        private readonly FloatGUI _guiM22 = new () { Title = "M22" };
        private readonly FloatGUI _guiM32 = new () { Title = "M32" };

        private readonly FloatGUI _guiM03 = new () { Title = "M03" };
        private readonly FloatGUI _guiM13 = new () { Title = "M13" };
        private readonly FloatGUI _guiM23 = new () { Title = "M23" };
        private readonly FloatGUI _guiM33 = new () { Title = "M33" };

        #endregion Field

        #region Property

        public override string Title
        {
            get => _foldoutPanel.Title;
            set => _foldoutPanel.Title = value;
        }

        public override Matrix4x4 MinValue
        {
            get => new () 
            {
                m00 = _guiM00.MinValue, 
                m10 = _guiM10.MinValue,
                m20 = _guiM20.MinValue,
                m30 = _guiM30.MinValue,

                m01 = _guiM01.MinValue,
                m11 = _guiM11.MinValue,
                m21 = _guiM21.MinValue,
                m31 = _guiM31.MinValue,

                m02 = _guiM02.MinValue,
                m12 = _guiM12.MinValue,
                m22 = _guiM22.MinValue,
                m32 = _guiM32.MinValue,

                m03 = _guiM03.MinValue,
                m13 = _guiM13.MinValue,
                m23 = _guiM23.MinValue,
                m33 = _guiM33.MinValue,
            };
            set
            {
                _guiM00.MinValue = value.m00;
                _guiM10.MinValue = value.m10;
                _guiM20.MinValue = value.m20;
                _guiM30.MinValue = value.m30;

                _guiM01.MinValue = value.m01;
                _guiM11.MinValue = value.m11;
                _guiM21.MinValue = value.m21;
                _guiM31.MinValue = value.m31;

                _guiM02.MinValue = value.m02;
                _guiM12.MinValue = value.m12;
                _guiM22.MinValue = value.m22;
                _guiM32.MinValue = value.m32;

                _guiM03.MinValue = value.m03;
                _guiM13.MinValue = value.m13;
                _guiM23.MinValue = value.m23;
                _guiM33.MinValue = value.m33;
            }
        }

        public override Matrix4x4 MaxValue
        {
            get => new () 
            {
                m00 = _guiM00.MaxValue,
                m10 = _guiM10.MaxValue,
                m20 = _guiM20.MaxValue,
                m30 = _guiM30.MaxValue,

                m01 = _guiM01.MaxValue,
                m11 = _guiM11.MaxValue,
                m21 = _guiM21.MaxValue,
                m31 = _guiM31.MaxValue,

                m02 = _guiM02.MaxValue,
                m12 = _guiM12.MaxValue,
                m22 = _guiM22.MaxValue,
                m32 = _guiM32.MaxValue,

                m03 = _guiM03.MaxValue,
                m13 = _guiM13.MaxValue,
                m23 = _guiM23.MaxValue,
                m33 = _guiM33.MaxValue,
            };
            set
            {
                _guiM00.MaxValue = value.m00;
                _guiM10.MaxValue = value.m10;
                _guiM20.MaxValue = value.m20;
                _guiM30.MaxValue = value.m30;

                _guiM01.MaxValue = value.m01;
                _guiM11.MaxValue = value.m11;
                _guiM21.MaxValue = value.m21;
                _guiM31.MaxValue = value.m31;

                _guiM02.MaxValue = value.m02;
                _guiM12.MaxValue = value.m12;
                _guiM22.MaxValue = value.m22;
                _guiM32.MaxValue = value.m32;

                _guiM03.MaxValue = value.m03;
                _guiM13.MaxValue = value.m13;
                _guiM23.MaxValue = value.m23;
                _guiM33.MaxValue = value.m33;
            }
        }

        public virtual int Decimals
        {
            get => _guiM00.Digits;
            set
            {
                _guiM00.Digits = value;
                _guiM10.Digits = value;
                _guiM20.Digits = value;
                _guiM30.Digits = value;

                _guiM01.Digits = value;
                _guiM11.Digits = value;
                _guiM21.Digits = value;
                _guiM31.Digits = value;

                _guiM02.Digits = value;
                _guiM12.Digits = value;
                _guiM22.Digits = value;
                _guiM32.Digits = value;

                _guiM03.Digits = value;
                _guiM13.Digits = value;
                _guiM23.Digits = value;
                _guiM33.Digits = value;
            }
        }

        public override float Width
        {
            get => _guiM00.Width;
            set
            {
                _guiM00.Width = value;
                _guiM10.Width = value;
                _guiM20.Width = value;
                _guiM30.Width = value;

                _guiM01.Width = value;
                _guiM11.Width = value;
                _guiM21.Width = value;
                _guiM31.Width = value;

                _guiM02.Width = value;
                _guiM12.Width = value;
                _guiM22.Width = value;
                _guiM32.Width = value;

                _guiM03.Width = value;
                _guiM13.Width = value;
                _guiM23.Width = value;
                _guiM33.Width = value;
            }
        }

        public override bool Slider
        {
            get => _guiM00.Slider;
            set
            {
                _guiM00.Slider = value;
                _guiM10.Slider = value;
                _guiM20.Slider = value;
                _guiM30.Slider = value;

                _guiM01.Slider = value;
                _guiM11.Slider = value;
                _guiM21.Slider = value;
                _guiM31.Slider = value;

                _guiM02.Slider = value;
                _guiM12.Slider = value;
                _guiM22.Slider = value;
                _guiM32.Slider = value;

                _guiM03.Slider = value;
                _guiM13.Slider = value;
                _guiM23.Slider = value;
                _guiM33.Slider = value;
            }
        }

        #endregion Property

        #region Constructor

        public Matrix4x4GUI() { }

        public Matrix4x4GUI(string title) : base(title) { }

        public Matrix4x4GUI(string title, Matrix4x4 min, Matrix4x4 max) : base(title, min, max) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            MinValue = XGUILayout.DefaultMinValueMatrix4x4;
            MaxValue = XGUILayout.DefaultMaxValueMatrix4x4;
        }

        public override Matrix4x4 Show(Matrix4x4 value)
        {
            _foldoutPanel.Show(() =>
            {
                XGUILayout.HorizontalLayout(() =>
                {
                    value.m00 = _guiM00.Show(value.m00);
                    value.m10 = _guiM10.Show(value.m10);
                    value.m20 = _guiM20.Show(value.m20);
                    value.m30 = _guiM30.Show(value.m30);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m01 = _guiM01.Show(value.m01);
                    value.m11 = _guiM11.Show(value.m11);
                    value.m21 = _guiM21.Show(value.m21);
                    value.m31 = _guiM31.Show(value.m31);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m02 = _guiM02.Show(value.m02);
                    value.m12 = _guiM12.Show(value.m12);
                    value.m22 = _guiM22.Show(value.m22);
                    value.m32 = _guiM32.Show(value.m32);
                });

                XGUILayout.HorizontalLayout(() =>
                {
                    value.m03 = _guiM03.Show(value.m03);
                    value.m13 = _guiM13.Show(value.m13);
                    value.m23 = _guiM23.Show(value.m23);
                    value.m33 = _guiM33.Show(value.m33);
                });
            });
            
            return value;
        }

        #endregion Method
    }
}