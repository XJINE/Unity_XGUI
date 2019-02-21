using System;
using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : Panel<int>
    {
        #region Property

        protected virtual GUIStyle TabStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.button);
                style.onNormal.background = Texture2D.blackTexture;
                return style;
            }
        }

        #endregion Property

        #region Method

        public virtual int Show(params Action[] show)
        {
            //this.labels.Clear();
            //foreach (TabPanelFunc tabPanelFunc in show)
            //{
            //    this.labels.Add(tabPanelFunc.Method.GetParameters()[0].RawDefaultValue)
            //}

            //XJGUILayout.VerticalLayout(()=> 
            //{
            //    base.ShowTitle();

            //    base.Value = GUILayout.Toolbar(base.Value, this.Labels, TabStyle);

            //    show[base.Value]();
            //});

            return base.Value;
        }

        #endregion Method
    }
}