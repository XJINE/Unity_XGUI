using System;
using UnityEngine;

namespace XJGUI
{
    public class FoldoutPanel : Panel<bool>
    {
        #region Filed

        protected bool value;

        #endregion Field

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

            XJGUILayout.VerticalLayout(() =>
            {
                string buttonContent = (this.value ? "\u25BC " : "\u25BA ") + base.Title;

                this.value = !(this.value == GUILayout.Button(buttonContent, TitleStyle));

                if (this.value)
                {
                    XJGUILayout.VerticalLayout(()=>
                    {
                        for (int i = 0; i < show.Length; i++)
                        {
                            show[i]();
                        }
                    });
                }
            }, this.value ? GUI.skin.box : null);

            return this.value;
        }

        #endregion Method
    }
}