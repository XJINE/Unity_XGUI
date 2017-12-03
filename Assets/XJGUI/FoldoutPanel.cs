using System;
using UnityEngine;

namespace XJGUI
{
    public class FoldoutPanel : PanelBaseGUI<bool>
    {
        #region Method

        public override bool Show(params Action[] guiActions)
        {
            // NOTE:
            // (value = true  && button = true)  => false
            // (value = true  && button = false) => true
            // (value = false && button = true)  => true
            // (value = false && button = false) => false

            string buttonContent = (base.value ? "\u25BC " : "\u25BA ") + base.title;

            base.value = !(base.value == GUILayout.Button(buttonContent));

            if (base.value)
            {
                XJGUILayout.VerticalLayout(()=>
                {
                    for (int i = 0; i < guiActions.Length; i++)
                    {
                        guiActions[i]();
                    }

                });
            }

            return base.value;
        }

        #endregion Method
    }
}