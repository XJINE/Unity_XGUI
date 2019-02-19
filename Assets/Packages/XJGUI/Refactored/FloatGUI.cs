﻿namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        #region Property

        protected override bool TextIsCorrect
        {
            get
            {
                float value;

                if (!float.TryParse(this.text, out value))
                {
                    return false;
                }

                if (value < base.MinValue || base.MaxValue < value)
                {
                    return false;
                }

                string[] splits = this.text.Split('.');

                if (splits.Length == 1)
                {
                    return true;
                }

                if (splits[1].Length <= base.Decimals)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion Property

        #region Constructor

        public FloatGUI() : base()
        {
            base.MinValue = XJGUILayout.DefaultMinValueFloat;
            base.MaxValue = XJGUILayout.DefaultMaxValueFloat;
            base.Value    = XJGUILayout.DefaultValueFloat;
        }

        #endregion Constructor

        #region Method

        protected override float CorrectValue(float value)
        {
            return (float)System.Math.Round(base.CorrectValue(value), base.Decimals);
        }

        #endregion Method
    }
}