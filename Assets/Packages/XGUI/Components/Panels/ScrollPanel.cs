﻿using System;
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

        public bool AlwaysShowHorizontal { get; set; }
        public bool AlwaysShowVertical   { get; set; }

        #endregion Property

        #region Constructor

        public ScrollPanel() { }

        public ScrollPanel(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public Vector2 Show(params Action[] actions)
        {
            var previousValue = Value;
            var height = Mathf.Min(MaxHeight, Mathf.Max(MinHeight, Height));
            var width  = Mathf.Min(MaxWidth,  Mathf.Max(MinWidth,  Width));

            XGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();
                XGUILayout.VerticalLayout(() =>
                    {
                        Value = GUILayout.BeginScrollView(Value, AlwaysShowHorizontal,
                                                                 AlwaysShowVertical,
                                                                 GUILayout.Width   (width),
                                                                 GUILayout.MinWidth(width),
                                                                 GUILayout.MaxWidth(width),
                                                                 GUILayout.Height  (height));
                        foreach (var action in actions)
                        {
                            action();
                        }

                        GUILayout.EndScrollView();
                    },
                    BoxSkin? GUI.skin.box : null, GUILayout.Height   (height),
                                                  GUILayout.MinHeight(height),
                                                  GUILayout.MaxHeight(height));
            });

            Updated = previousValue != Value;

            return Value;
        }

        #endregion Method
    }
}