﻿using System;
using UnityEngine;

namespace XJGUI
{
    public class FlexibleWindow : BaseGUI<Rect>
    {
        #region Field

        private float previousShowTime;

        #endregion Field

        #region Property

        public int ID { get; private set; }
        public float MinWidth { get; set; }
        public float MinHeight { get; set; }
        public float MaxWidth { get; set; }
        public float MaxHeight { get; set; }
        public bool  IsDraggable { get; set; }
        public bool  IsVisible { get; set; }

        #endregion Property

        #region Constructor

        public FlexibleWindow()
        {
            // NOTE:
            // Guid.NewGuid().GetHashCode get collision at sometimes but its very rare case.
            // It is enough to use it as WindowID.
            // https://blogs.msdn.microsoft.com/ericlippert/2010/03/22/socks-birthdays-and-hash-collisions/

            this.ID = Guid.NewGuid().GetHashCode();

            this.Title       = XJGUILayout.DefaultWindowTitle;
            this.MinWidth    = XJGUILayout.DefaultWindowMinWidth;
            this.MinHeight   = XJGUILayout.DefaultWindowMinHeight;
            this.MaxWidth    = XJGUILayout.DefaultWindowMaxWidth;
            this.MaxHeight   = XJGUILayout.DefaultWindowMaxHeight;
            this.IsDraggable = XJGUILayout.DefaultWindowIsDraggable;
            this.IsVisible   = XJGUILayout.DefaultWindowIsVisible;
        }

        #endregion Constructor

        #region Method

        public Rect Show(params Action[] guiAction)
        {
            if (!this.IsVisible)
            {
                return new Rect(this.Value.position.x, this.Value.position.y, 0, 0);
            }

            GUI.WindowFunction windowFunction;

            if (this.IsDraggable)
            {
                windowFunction = (int windowID) =>
                {
                    for (int i = 0; i < guiAction.Length; i++)
                    {
                        guiAction[i]();
                    }

                    GUI.DragWindow();
                };
            }
            else
            {
                windowFunction = (int windowID) =>
                {
                    for (int i = 0; i < guiAction.Length; i++)
                    {
                        guiAction[i]();
                    }
                };
            }

            // NOTE:
            // GUILayout.Window will render stretched window when width or height = 0.
            // However, there is a problem to render window with 0 width (or height).
            // When the window is dragged, it will blink.
            // This problem is not always occur, but when application gets more heavy, it will more occur.
            // 
            // Maybe this is because of the OnGUI method is called twice in a game-loop.
            // To resolve this problem, this method render the window with 0 width (or height) in 1st call.
            // And in 2nd call, render the window with 1st call result size.

            if (this.previousShowTime != Time.timeSinceLevelLoad)
            {
                this.Value = new Rect(this.Value.x, this.Value.y, 0, 0);
                this.previousShowTime = Time.timeSinceLevelLoad;
            }

            this.Value = GUILayout.Window(this.ID, this.Value, windowFunction, this.Title,
                                         GUILayout.MinWidth(this.MinWidth),
                                         GUILayout.MinHeight(this.MinHeight),
                                         GUILayout.MaxWidth(this.MaxWidth),
                                         GUILayout.MaxHeight(this.MaxHeight));

            return this.Value;
        }

        public bool ToggleVisibility()
        {
            this.IsVisible = !this.IsVisible;
            return this.IsVisible;
        }

        #endregion Method
    }
}