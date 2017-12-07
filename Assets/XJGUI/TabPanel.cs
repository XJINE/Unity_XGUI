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

                if (GUI.skin.label.normal.background == null)
                {
                    TabPanel.ButtonStyle.onNormal.background = XJGUILayout.TransparentTexture;
                }
                else
                {
                    TabPanel.ButtonStyle.onNormal.background = GUI.skin.label.normal.background;
                }
            }

            //if (functions.Length != this.labels.Length)
            //{
            //    throw new Exception(string.Format(ErrorMessage.DifferentDataLengthError, functions, this.labels));
            //}

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