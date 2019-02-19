using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : PanelGUI<int>
    {
        #region Field

        public delegate void TabPanelFunc(string title);

        #endregion Field

        #region Property

        public string[] Labels { get; set; }

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

        public override int Show(params Action[] show)
        {
            XJGUILayout.VerticalLayout(()=> 
            {
                base.ShowTitle();

                base.Value = GUILayout.Toolbar(base.Value, this.Labels, TabStyle);

                show[base.Value]();
            });

            return base.Value;
        }

        #endregion Method
    }
}