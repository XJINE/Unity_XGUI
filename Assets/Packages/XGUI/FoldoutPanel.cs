using System;
using UnityEngine;

namespace XGUI
{
    public class FoldoutPanel : Panel<bool>
    {
        #region Constructor

        public FoldoutPanel() : base() { }

        public FoldoutPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public virtual bool Show(params Action[] show)
        {
            // NOTE:
            // (value = true  && button = true)  => false
            // (value = true  && button = false) => true
            // (value = false && button = true)  => true
            // (value = false && button = false) => false

            XGUILayout.VerticalLayout(() =>
            {
                string buttonContent = (base.value ? "\u25BC " : "\u25BA ") + base.Title;

                base.value = !(base.value == GUILayout.Button(buttonContent, TitleStyle));

                if (base.value)
                {
                    XGUILayout.VerticalLayout(()=>
                    {
                        for (int i = 0; i < show.Length; i++)
                        {
                            show[i]();
                        }
                    });
                }
            }, base.value ? GUI.skin.box : null);

            return base.value;
        }

        #endregion Method
    }
}