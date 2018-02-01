using System;
using UnityEngine;

namespace XJGUI
{
    public class ScrollPanel : PanelGUI<Vector2>
    {
        #region Field

        protected float minWidth = 0;
        protected float maxWidth = float.MaxValue;

        protected float minHeight = 0;
        protected float maxHeight = float.MaxValue;

        #endregion Field

        #region Property

        public float MinWidth
        {
            get { return this.minWidth; }
            set { this.minWidth = value; }
        }

        public float MinHeight
        {
            get { return this.minHeight; }
            set { this.minHeight = value; }
        }

        public float MaxWidth
        {
            get { return this.maxWidth; }
            set { this.maxWidth = value; }
        }

        public float MaxHeight
        {
            get { return this.maxHeight; }
            set { this.maxHeight = value; }
        }

        #endregion Property

        #region Method

        public override Vector2 Show(params Action[] guiActions)
        {
            base.value = GUILayout.BeginScrollView(base.value, GUILayout.MinWidth(this.minWidth),
                                                               GUILayout.MinHeight(this.minHeight),
                                                               GUILayout.MaxWidth(this.maxWidth),
                                                               GUILayout.MaxHeight(this.maxHeight));

            for (int i = 0; i < guiActions.Length; i++)
            {
                guiActions[i]();
            }

            GUILayout.EndScrollView();

            return base.value;
        }
        #endregion Method
    }
}