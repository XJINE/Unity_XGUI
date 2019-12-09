using System;
using UnityEngine;

namespace XGUI
{
    public class ScrollPanel : Panel<Vector2>
    {
        #region Property

        public float Width     { get; set; }
        public float Height    { get; set; }
        public float MinWidth  { get; set; }
        public float MinHeight { get; set; }
        public float MaxWidth  { get; set; } = float.MaxValue;
        public float MaxHeight { get; set; } = float.MaxValue;

        #endregion Property

        #region Constructor

        public ScrollPanel() : base() { }

        public ScrollPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public virtual Vector2 Show(params Action[] show)
        {
            base.ShowTitle();

            float height = Mathf.Min(this.MaxHeight, Mathf.Max(this.MinHeight, this.Height));
            float width  = Mathf.Min(this.MaxWidth,  Mathf.Max(this.MinWidth,  this.Width));

            GUILayout.BeginVertical(GUILayout.Height   (height),
                                    GUILayout.MinHeight(height),
                                    GUILayout.MaxHeight(height));

            base.value = GUILayout.BeginScrollView(base.value, GUILayout.Width   (width),
                                                               GUILayout.MinWidth(width),
                                                               GUILayout.MaxWidth(width),
                                                               GUILayout.Height(height));

            for (int i = 0; i < show.Length; i++)
            {
                show[i]();
            }

            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            return base.value;
        }

        #endregion Method
    }
}