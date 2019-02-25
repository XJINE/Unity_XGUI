using System;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // T must be "enum" type.

    // CAUTION:
    // Enum.GetValues return wrong pattern in sometimes.
    // If some of the Enum components has a same value, the values has same Enum components.
    // Ex. When Enum is defined like this {EnumA = 0, EnumB = 0},
    // Enum.GetValues will return 2 EnumB, and the EnumA is not included there.
    // 
    // So we should Name based implement. However, still have another problem.
    // When try to Enum.Parse in same case, it returns EnumB only.
    // Even if the string value shows "EnumA", Enum.Parse returns EnumB.
    // I try to use Reflection, but the result was not good.

    public class EnumGUI<T> : Element<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Field

        protected Type enumType;

        protected string[] enumNames;

        protected int selectedIndex;

        protected bool isEditing;

        #endregion Field

        #region Property

        public override T Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                this.selectedIndex = GetSelectedEnumIndex(value);
                base.Value = value;
            }
        }

        public float ButtonWidth { get; set; }

        protected GUIStyle ButtonStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.button);

                if (this.isEditing)
                {
                    style.normal = GUI.skin.button.active;
                }

                return style;
            }
        }
        
        protected GUILayoutOption ButtonLayout
        {
            get { return this.ButtonWidth <= 0 ? null : GUILayout.Width(this.ButtonWidth); }
        }

        #endregion Property

        #region Constructor

        public EnumGUI() : base() { }

        public EnumGUI(string title) : base(title) { }

        public EnumGUI(string title, T value) : base(title, value) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.ButtonWidth = XJGUILayout.DefaultButtonWidth;

            this.enumType = typeof(T);

            if (!this.enumType.IsEnum)
            {
                // Exception.
            }

            this.enumNames = Enum.GetNames(this.enumType);
        }

        public override T Show()
        {
            XJGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();

                if (this.ButtonWidth > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                if (GUILayout.Button(this.enumNames[this.selectedIndex],
                                     this.ButtonStyle,
                                     this.ButtonLayout))
                {
                    this.isEditing = !this.isEditing;
                }
            });

            if (!this.isEditing)
            {
                return Value;
            }

            XJGUILayout.HorizontalLayout(() =>
            {
                if(this.ButtonWidth > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                XJGUILayout.VerticalLayout(() =>
                {
                    for (int i = 0; i < this.enumNames.Length; i++)
                    {
                        if (i == this.selectedIndex)
                        {
                            continue;
                        }

                        if (GUILayout.Button(this.enumNames[i], ButtonLayout))
                        {
                            this.selectedIndex = i;
                            this.isEditing = false;
                            base.Value = (T)Enum.Parse(this.enumType, this.enumNames[i]);
                        }
                    }

                }, GUI.skin.box);
            });

            return this.Value;
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