using System;
using UnityEngine;

namespace XJGUI
{
    public class FoldoutPanel : Panel<bool>
    {
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
                string buttonContent = (base.Value ? "\u25BC " : "\u25BA ") + base.Title;

                base.Value = !(base.Value == GUILayout.Button(buttonContent, base.TitleStyle));

                if (base.Value)
                {
                    XJGUILayout.VerticalLayout(()=>
                    {
                        for (int i = 0; i < show.Length; i++)
                        {
                            show[i]();
                        }
                    });
                }
            }, base.Value ? GUI.skin.box : null);

            return base.Value;
        }

        #endregion Method
    }
}