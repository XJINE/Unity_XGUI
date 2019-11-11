using System;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // FlexibleWindow is not an inheritance of Component class
    // because it doesn't need ShowTitle().

    public class FlexWindow : BaseGUI<Rect>
    {
        #region Field

        protected Rect value;

        private float previousShowTime;

        #endregion Field

        #region Property

        public Vector2 Position
        {
            get { return new Vector2(this.value.x, this.value.y); }
            set { this.value.x = value.x; this.value.y = value.y; }
        }

        public int   ID          { get; private set; }
        public float MinWidth    { get; set; }
        public float MinHeight   { get; set; }
        public float MaxWidth    { get; set; }
        public float MaxHeight   { get; set; }
        public bool  IsDraggable { get; set; }
        public bool  IsVisible   { get; set; }

        #endregion Property

        #region Constructor

        public FlexWindow() : base() { }

        public FlexWindow(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            // NOTE:
            // Guid.NewGuid().GetHashCode get collision at sometimes but its very rare case.
            // It is enough to use it as WindowID.
            // https://blogs.msdn.microsoft.com/ericlippert/2010/03/22/socks-birthdays-and-hash-collisions/

            this.ID          = Guid.NewGuid().GetHashCode();
            this.MinWidth    = XGUILayout.DefaultWindowMinWidth;
            this.MinHeight   = XGUILayout.DefaultWindowMinHeight;
            this.MaxWidth    = XGUILayout.DefaultWindowMaxWidth;
            this.MaxHeight   = XGUILayout.DefaultWindowMaxHeight;
            this.IsDraggable = XGUILayout.DefaultWindowIsDraggable;
            this.IsVisible   = XGUILayout.DefaultWindowIsVisible;
        }

        public Rect Show(params Action[] guiAction)
        {
            if (!this.IsVisible)
            {
                return new Rect(this.value.position.x, this.value.position.y, 0, 0);
            }

            GUI.WindowFunction windowFunction = (int windowID) =>
            {
                for (int i = 0; i < guiAction.Length; i++)
                {
                    guiAction[i]();
                }

                if (this.IsDraggable)
                {
                    GUI.DragWindow();
                }
            };

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
                this.value = new Rect(this.value.x, this.value.y, 0, 0);
                this.previousShowTime = Time.timeSinceLevelLoad;
            }

            this.value = GUILayout.Window(this.ID,
                                          this.value,
                                          windowFunction,
                                          base.Title,
                                          GUILayout.MinWidth (this.MinWidth),
                                          GUILayout.MinHeight(this.MinHeight),
                                          GUILayout.MaxWidth (this.MaxWidth),
                                          GUILayout.MaxHeight(this.MaxHeight));

            return this.value;
        }

        #endregion Method
    }
}