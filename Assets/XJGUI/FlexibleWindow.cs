using System;
using UnityEngine;

namespace XJGUI
{
    public class FlexibleWindow
    {
        #region Field

        public string title;

        public float minWidth;
        public float minHeight;
        public float maxWidth;
        public float maxHeight;

        public bool isDraggable;
        public bool isVisible;

        private float previousShowTime;

        #endregion Field

        #region Property

        public Rect Value
        {
            get;
            set;
        }

        public int ID
        {
            get;
            private set;
        }

        #endregion Property

        #region Constructor

        public FlexibleWindow()
        {
            // NOTE:
            // Guid.NewGuid().GetHashCode get collision at sometimes but its very rare case.
            // It is enough to use it as WindowID.
            // https://blogs.msdn.microsoft.com/ericlippert/2010/03/22/socks-birthdays-and-hash-collisions/

            this.ID = Guid.NewGuid().GetHashCode();
        }

        #endregion Constructor

        #region Method

        public Rect Show(Action guiAction)
        {
            if (!this.isVisible)
            {
                return new Rect(this.Value.position.x, this.Value.position.y, 0, 0);
            }

            GUI.WindowFunction windowFunction;

            if (this.isDraggable)
            {
                windowFunction = (int windowID) =>
                {
                    guiAction();
                    GUI.DragWindow();
                };
            }
            else
            {
                windowFunction = (int windowID) =>
                {
                    guiAction();
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

            this.Value = GUILayout.Window(this.ID, this.Value, windowFunction, this.title,
                                         GUILayout.MinWidth(this.minWidth),
                                         GUILayout.MinHeight(this.minHeight),
                                         GUILayout.MaxWidth(this.maxWidth),
                                         GUILayout.MaxHeight(this.maxHeight));

            return this.Value;
        }

        #endregion Method
    }
}