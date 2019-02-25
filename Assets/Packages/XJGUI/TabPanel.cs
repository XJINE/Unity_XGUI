using System;
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

        #region Constructor

        public TabPanel() : base() { }

        public TabPanel(string title) { }

        public TabPanel(string title, int value) : base(title, value) { }

        #endregion Constructor

        #region Method

        public class Func
        {
            public string label;
            public Action show;

            public Func(string label, Action show)
            {
                this.label = label;
                this.show  = show;
            }
        }

        public virtual int Show(params Func[] show)
        {
            var labels = new string[show.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = show[i].label;
            }

            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                base.Value = GUILayout.Toolbar(base.Value, labels, TabStyle);

                show[base.Value].show();

            }, GUI.skin.box);

            return base.Value;
        }
        
        #endregion Method
    }
}