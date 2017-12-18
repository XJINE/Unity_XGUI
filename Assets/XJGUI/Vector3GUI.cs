﻿using UnityEngine;

namespace XJGUI
{
    public class Vector3GUI : VectorGUI<Vector3>
    {
        #region Field

        private FloatGUI floatGUIX;
        private FloatGUI floatGUIY;
        private FloatGUI floatGUIZ;

        #endregion Field

        #region Property

        public override Vector3 Value
        {
            get
            {
                return base.value;
            }
            set
            {
                this.floatGUIX.Value = value.x;
                this.floatGUIY.Value = value.y;
                this.floatGUIZ.Value = value.z;

                base.value = new Vector3()
                {
                    x = this.floatGUIX.Value,
                    y = this.floatGUIY.Value,
                    z = this.floatGUIZ.Value
                };
            }
        }

        public override Vector3 MinValue
        {
            get
            {
                return new Vector3()
                {
                    x = this.floatGUIX.MinValue,
                    y = this.floatGUIY.MinValue,
                    z = this.floatGUIZ.MinValue
                };
            }
            set
            {
                this.floatGUIX.MinValue = value.x;
                this.floatGUIY.MinValue = value.y;
                this.floatGUIZ.MinValue = value.z;
            }
        }

        public override Vector3 MaxValue
        {
            get
            {
                return new Vector3()
                {
                    x = this.floatGUIX.MaxValue,
                    y = this.floatGUIY.MaxValue,
                    z = this.floatGUIZ.MaxValue
                };
            }
            set
            {
                this.floatGUIX.MaxValue = value.x;
                this.floatGUIY.MaxValue = value.y;
                this.floatGUIZ.MaxValue = value.z;
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
                this.floatGUIZ.FieldWidth = value;
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
                this.floatGUIZ.WithSlider = value;
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
                this.floatGUIZ.Decimals = value;
            }
        }

        #endregion Property

        #region Constructor

        public Vector3GUI() : base()
        {
            this.floatGUIX = new FloatGUI() { Title = "X" };
            this.floatGUIY = new FloatGUI() { Title = "Y" };
            this.floatGUIZ = new FloatGUI() { Title = "Z" };

            // NOTE:
            // Set min/max value first. If not, "Value" will collect with min/ max value 0.

            this.MinValue = XJGUILayout.DefaultMinValueVector3;
            this.MaxValue = XJGUILayout.DefaultMaxValueVector3;
            this.Value = XJGUILayout.DefaultValueVector3;
        }

        #endregion Constructor

        #region Method

        protected override void ShowComponentGUI()
        {
            this.value.x = this.floatGUIX.Show();
            this.value.y = this.floatGUIY.Show();
            this.value.z = this.floatGUIZ.Show();
        }

        #endregion Method
    }
}