using System;
using UnityEngine;

namespace XGUI
{
    public class FoldoutPanel : Panel<bool>
    {
        #region Constructor

        public FoldoutPanel() { }

        public FoldoutPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public bool Show(params Action[] actions)
        {
            XGUILayout.VerticalLayout(() =>
            {
                var buttonContent = (Value ? "\u25BC " : "\u25BA ") + Title;

                Value = Value != GUILayout.Button(buttonContent, TitleStyle);

                if (Value)
                {
                    XGUILayout.VerticalLayout(()=>
                    {
                        foreach (var action in actions)
                        {
                            action();
                        }
                    });
                }
            }, Value ? GUI.skin.box : null);

            return Value;
        }

        #endregion Method
    }
}