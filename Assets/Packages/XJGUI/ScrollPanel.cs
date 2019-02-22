using System;
using UnityEngine;

namespace XJGUI
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

        #region Method

        public virtual Vector2 Show(params Action[] show)
        {
            base.ShowTitle();

            float height = Mathf.Min(this.MaxHeight, Mathf.Max(this.MinHeight, this.Height));
            float width  = Mathf.Min(this.MaxWidth,  Mathf.Max(this.MinWidth,  this.Width));

            GUILayout.BeginVertical(GUILayout.Height   (height),
                                    GUILayout.MinHeight(height),
                                    GUILayout.MaxHeight(height));

            base.Value = GUILayout.BeginScrollView(base.Value, GUILayout.Width   (width),
                                                               GUILayout.MinWidth(width),
                                                               GUILayout.MaxWidth(width),
                                                               GUILayout.Height(height));

            for (int i = 0; i < show.Length; i++)
            {
                show[i]();
            }

            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            return base.Value;
        }
        #endregion Method
    }
}