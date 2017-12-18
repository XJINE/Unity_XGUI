using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : PanelGUI<int>
    {
        #region Field

        private static GUIStyle ButtonStyle;

        #endregion Field

        #region Property

        public string[] Labels { get; set; }

        #endregion Property

        #region Method

        public override int Show(params Action[] guiAction)
        {
            if (TabPanel.ButtonStyle == null)
            {
                TabPanel.ButtonStyle = new GUIStyle(GUI.skin.button);

                TabPanel.ButtonStyle.onNormal.background
                    = XJGUILayout.Generate1x1Texture(Color.clear);
            }

            XJGUILayout.VerticalLayout((Action)(()=> 
            {
                base.ShowTitle();

                base.Value = GUILayout.Toolbar(base.Value, this.Labels, TabPanel.ButtonStyle);

                guiAction[base.Value]();
            }));

            return base.Value;
        }

        #endregion Method
    }
}