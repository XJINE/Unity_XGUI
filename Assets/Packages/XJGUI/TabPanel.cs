using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : Panel<int>
    {
        #region Field

        protected int value = 0;

        #endregion Field

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

            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                this.value = GUILayout.Toolbar(this.value, labels, TabStyle);

                tabs[this.value].show();

            }, GUI.skin.box);

            return this.value;
        }

        #endregion Method
    }
}