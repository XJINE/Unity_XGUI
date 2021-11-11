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

        public ScrollPanel() { }

        public ScrollPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public Vector2 Show(params Action[] actions)
        {
            base.ShowTitle();

            var height = Mathf.Min(MaxHeight, Mathf.Max(MinHeight, Height));
            var width  = Mathf.Min(MaxWidth,  Mathf.Max(MinWidth,  Width));

            GUILayout.BeginVertical(GUILayout.Height   (height),
                                    GUILayout.MinHeight(height),
                                    GUILayout.MaxHeight(height));

            Value = GUILayout.BeginScrollView(Value, GUILayout.Width   (width),
                                                     GUILayout.MinWidth(width),
                                                     GUILayout.MaxWidth(width),
                                                     GUILayout.Height(height));

            foreach (var action in actions)
            {
                action();
            }

            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            return Value;
        }

        #endregion Method
    }
}