using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be 'int' or 'float'.

    public abstract class NumericGUI<T> : ValueGUI<T> where T : struct, IComparable
    {
        #region Field

        // NOTE:
        // "text" must be initialized in inheritance class.
        // It is same as "value" initialize.In most cases, initialize with "Value" property.

        protected string text;

        protected Color textColor;

        #endregion Field

        #region Property

        public override T Value
        {
            get
            {
                return base.value;
            }
            set
            {
                base.value = CorrectValue(value);
                this.text = base.value.ToString();
            }
        }

        public override T MinValue
        {
            get
            {
                return base.minValue;
            }
            set
            {
                base.minValue = value;
                this.Value = base.value;
            }
        }

        public override T MaxValue
        {
            get
            {
                return base.maxValue;
            }
            set
            {
                base.maxValue = value;
                this.Value = base.value;
            }
        }

        #endregion Property

        #region Method

        protected virtual T CorrectValue(T value)
        {
            if (0 < value.CompareTo(base.MaxValue))
            {
                value = base.MaxValue;
            }

            if (value.CompareTo(base.MinValue) < 0)
            {
                value = base.MinValue;
            }

            return value;
        }

        protected void UpdateTextFieldColor()
        {
            bool textIsCoorect = TextIsCorrect();

            ValueGUI<T>.TextFieldStyle.normal.textColor 
                = !textIsCoorect ? XJGUILayout.DefaultInvalidValueColor
                                 : GUI.skin.textField.normal.textColor;

            ValueGUI<T>.TextFieldStyle.active.textColor
                = !textIsCoorect ? XJGUILayout.DefaultInvalidValueColor
                                 : GUI.skin.textField.active.textColor;

            ValueGUI<T>.TextFieldStyle.focused.textColor
                = !textIsCoorect ? XJGUILayout.DefaultInvalidValueColor
                                 : GUI.skin.textField.focused.textColor;
        }

        protected abstract bool TextIsCorrect();

        #endregion Method
    }
}