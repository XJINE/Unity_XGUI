using System;
using UnityEngine;

namespace XGUI
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

    public class EnumGUI<T> : Element<T> where T : Enum
    {
        #region Field

        protected bool isEditing;

        #endregion Field

        #region Property

        public float Width { get; set; }

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
            get { return this.Width <= 0 ? null : GUILayout.Width(this.Width); }
        }

        #endregion Property

        #region Constructor

        public EnumGUI() : base() { }

        public EnumGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            this.Width = XGUILayout.DefaultWidth;
        }

        public override T Show(T value)
        {
            Type     enumType  = value.GetType();
            string[] enumNames = Enum.GetNames(enumType);
            int selectedIndex  = GetSelectedIndex(value, enumNames);

            XGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();

                if (this.Width > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                if (GUILayout.Button(enumNames[selectedIndex],
                                     this.ButtonStyle,
                                     this.ButtonLayout))
                {
                    this.isEditing = !this.isEditing;
                }
            });

            if (!this.isEditing)
            {
                return value;
            }

            XGUILayout.HorizontalLayout(() =>
            {
                if(this.Width > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                XGUILayout.VerticalLayout(() =>
                {
                    for (int i = 0; i < enumNames.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            continue;
                        }

                        if (GUILayout.Button(enumNames[i], ButtonLayout))
                        {
                            this.isEditing = false;
                            value = (T)Enum.Parse(enumType, enumNames[i]);
                        }
                    }

                }, GUI.skin.box);
            });

            return value;
        }

        protected int GetSelectedIndex(Enum value, string[] enumNames)
        {
            string enumName = value.ToString();

            for (int i = 0; i < enumNames.Length; i++)
            {
                if (enumNames[i] == enumName)
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion Method
    }
}