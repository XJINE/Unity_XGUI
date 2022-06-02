using System;
using UnityEngine;

namespace XGUI
{
    public class FoldoutPanel : Panel<bool>
    {
        #region Field

        public Action ButtonFieldAction;

        private   static GUIStyle _foldoutButtonStyle;
        protected static GUIStyle FoldoutButtonStyle
        {
            get
            {
                _foldoutButtonStyle ??= new GUIStyle(GUI.skin.label)
                {
                    margin  = GUI.skin.button.margin,
                    padding = GUI.skin.button.padding
                };

                return _foldoutButtonStyle;
            }
        }

        private   static GUIStyle _foldoutBoxStyle;
        protected static GUIStyle FoldoutBoxStyle
        {
            get
            {
                _foldoutBoxStyle ??= new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(GUI.skin.font.fontSize,
                                             GUI.skin.box.padding.right,
                                             GUI.skin.box.padding.top,
                                             GUI.skin.box.padding.bottom)
                };

                return _foldoutBoxStyle;
            }
        }

        #endregion Field

        #region Constructor

        public FoldoutPanel() { }

        public FoldoutPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public bool Show(params Action[] actions)
        {
            var previousValue = Value;

            XGUILayout.VerticalLayout(() =>
            {
                var buttonContent = (Value ? "\u25BC " : "\u25BA ") + Title;

                XGUILayout.HorizontalLayout(() =>
                {
                    var expand = !string.IsNullOrEmpty(Title);
                    Value = Value != GUILayout.Button(buttonContent, FoldoutButtonStyle, GUILayout.ExpandWidth(expand));
                    ButtonFieldAction?.Invoke();
                });

                if (Value)
                {
                    XGUILayout.VerticalLayout(()=>
                    {
                        foreach (var action in actions)
                        {
                            action();
                        }
                    }, FoldoutBoxStyle);
                }
            }, Value && BoxSkin ? GUI.skin.box : null);

            Updated = previousValue != Value;

            return Value;
        }

        #endregion Method
    }
}