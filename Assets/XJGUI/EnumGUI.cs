using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be "enum" type.

    // CAUTION:
    // Enum.GetValues return wrong pattern in sometimes.
    // If some of the Enum components has a same value, the values has same Enum components.
    // Ex. When Enum is defined like this {valueA = 0, valueB = 0},
    // Enum.GetValues will return 2 valueB and valueA is not included there.
    // So we need to Name based implement.

    public class EnumGUI<T> : ElementGUI<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Field

        protected Type enumType;

        protected string[] enumNames;

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

            if (!this.enumType.IsEnum)
            {
                // Exception.
            }

            this.enumNames = Enum.GetNames(this.enumType);
        }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();

                string buttonContent = this.enumNames[this.selectedIndex];

                if (this.ButtonWidth <= 0 ? GUILayout.Button(buttonContent)
                                          : GUILayout.Button(buttonContent, GUILayout.Width(this.ButtonWidth)))
                {
                    this.isEditing = !this.isEditing;
                }
            });

            if (!this.isEditing)
            {
                return this.Value;
            }

            for (int i = 0; i < this.enumNames.Length; i++)
            {
                if (i == this.selectedIndex)
                {
                    continue;
                }

                bool buttonPressed = false;
                string buttonContent = this.enumNames[i];

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
                    base.value = (T)Enum.Parse(this.enumType, this.enumNames[i]);
                }
            }

            return base.Value;
        }

        protected int GetSelectedEnumIndex(T value)
        {
            string enumName = value.ToString();

            for (int i = 0; i < this.enumNames.Length; i++)
            {

                if (this.enumNames[i] == enumName)
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion Method
    }
}