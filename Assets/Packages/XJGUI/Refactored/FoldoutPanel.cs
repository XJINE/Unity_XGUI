﻿using System;
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

            XJGUILayout.VerticalLayout(() =>
            {
                string buttonContent = (base.Value ? "\u25BC " : "\u25BA ") + base.Title;

                base.Value = !(base.Value == GUILayout.Button(buttonContent, base.GetTitleStyle()));

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
            }, base.Value ? GUI.skin.box : null);

            return base.Value;
        }

        #endregion Method
    }
}