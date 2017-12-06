using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be "enum" type.

    public class EnumGUI<T> : ElementBaseGUI<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Field

        protected Type enumType;

        protected T[] enumValues;

        protected int selectedIndex;

        protected bool isEditing;

        protected float buttonWidth;

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
                this.selectedIndex = GetSelectedEnumIndex(value);
                base.value = value;
            }
        }

        public float ButtonWidth
        {
            get { return this.buttonWidth; }
            set { this.buttonWidth = value; }
        }

        #endregion Property

        #region Constructor

        public EnumGUI() : base()
        {
            this.enumType = typeof(T);

            if (this.enumType.IsEnum)
            {
                // Exception.
            }

            Array enumValues = Enum.GetValues(this.enumType);
            this.enumValues = new T[enumValues.Length];

            for (int i = 0; i < enumValues.Length; i++)
            {
                this.enumValues[i] = (T)enumValues.GetValue(i);
            }
        }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();

                string buttonContent = this.enumValues[this.selectedIndex].ToString();

                if (this.ButtonWidth <= 0 ? GUILayout.Button(buttonContent)
                                          : GUILayout.Button(buttonContent, GUILayout.Width(this.ButtonWidth)))
                {
                    this.isEditing = !this.isEditing;
                }
            });

            if (!this.isEditing)
            {
                return base.Value;
            }

            for (int i = 0; i < this.enumValues.Length; i++)
            {
                if (i == this.selectedIndex)
                {
                    continue;
                }

                bool buttonPressed = false;
                string buttonContent = this.enumValues[i].ToString();

                if (this.ButtonWidth <= 0)
                {
                    buttonPressed = GUILayout.Button(buttonContent);
                }
                else
                {
                    XJGUILayout.HorizontalLayout(()=> 
                    {
                        GUILayout.FlexibleSpace();
                        buttonPressed = GUILayout.Button(buttonContent, GUILayout.Width(this.ButtonWidth));
                    });
                }

                if (buttonPressed)
                {
                    this.selectedIndex = i;
                    this.isEditing = false;
                    base.Value = this.enumValues[i];
                }
            }

            return base.Value;
        }

        protected int GetSelectedEnumIndex(T value)
        {
            for (int i = 0; i < this.enumValues.Length; i++)
            {
                if (this.enumValues[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion Method
    }
}