using System;
using UnityEngine;

namespace XGUI
{
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

    public class EnumGUI<T> : ElementGUI<T> where T : Enum
    {
        #region Field

        private bool _isEditing;

        #endregion Field

        #region Property

        public float Width { get; set; }

        private static GUIStyle _buttonStyle;
        private GUIStyle ButtonStyle
        {
            get
            {
                _buttonStyle ??= new GUIStyle(GUI.skin.button);
                _buttonStyle.normal = _isEditing ? GUI.skin.button.active
                                                 : GUI.skin.button.normal;
                return _buttonStyle;
            }
        }
        
        private GUILayoutOption ButtonLayout
        {
            get => Width <= 0 ? null : GUILayout.Width(Width);
        }

        #endregion Property

        #region Constructor

        public EnumGUI() { }

        public EnumGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            Width = XGUILayout.DefaultWidth;
        }

        public override T Show(T value)
        {
            var enumType      = value.GetType();
            var enumNames     = Enum.GetNames(enumType);
            var selectedIndex = GetSelectedIndex(value, enumNames);

            XGUILayout.HorizontalLayout(() =>
            {
                base.ShowTitle();

                if (Width > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                if (GUILayout.Button(enumNames[selectedIndex], ButtonStyle, ButtonLayout))
                {
                    _isEditing = !_isEditing;
                }
            });

            if (!_isEditing)
            {
                return value;
            }

            XGUILayout.HorizontalLayout(() =>
            {
                if(Width > 0)
                {
                    GUILayout.FlexibleSpace();
                }

                XGUILayout.VerticalLayout(() =>
                {
                    for (var i = 0; i < enumNames.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            continue;
                        }

                        if (GUILayout.Button(enumNames[i], ButtonLayout))
                        {
                            _isEditing = false;
                            value = (T)Enum.Parse(enumType, enumNames[i]);
                        }
                    }

                }, GUI.skin.box);
            });

            return value;
        }

        private static int GetSelectedIndex(Enum value, string[] enumNames)
        {
            var enumName = value.ToString();

            for (var i = 0; i < enumNames.Length; i++)
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