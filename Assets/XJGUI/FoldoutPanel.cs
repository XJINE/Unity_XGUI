using System;
using UnityEngine;

namespace XJGUI
{
    public class FoldoutPanel : PanelGUI<bool>
    {
        #region Method

        public override bool Show(params Action[] guiActions)
        {
            // NOTE:
            // (value = true  && button = true)  => false
            // (value = true  && button = false) => true
            // (value = false && button = true)  => true
            // (value = false && button = false) => false

            string buttonContent = (base.Value ? "\u25BC " : "\u25BA ") + base.Title;

            GUIStyle guiStyle = base.BoldTitle ? XJGUILayout.BoldLabelStyle : GUIStyle.none;

            base.Value = !(base.Value == GUILayout.Button(buttonContent, guiStyle));

            if (base.Value)
            {
                XJGUILayout.VerticalLayout(()=>
                {
                    for (int i = 0; i < guiActions.Length; i++)
                    {
                        guiActions[i]();
                    }

                });
            }

            return base.Value;
        }

        #endregion Method
    }
}