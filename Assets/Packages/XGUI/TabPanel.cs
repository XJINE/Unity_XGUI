using System;
using UnityEngine;

namespace XGUI
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

        #region Constructor

        public TabPanel() : base() { }

        public TabPanel(string title) { }

        #endregion Constructor

        #region Method

        public virtual int Show(params (string label, Action show)[] tabs)
        {
            var labels = new string[tabs.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = tabs[i].label;
            }

            XGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                base.value = GUILayout.Toolbar(base.value, labels, TabStyle);

                tabs[base.value].show();

            }, GUI.skin.box);

            return base.value;
        }

        #endregion Method
    }
}