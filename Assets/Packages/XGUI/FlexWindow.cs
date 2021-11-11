using System;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // FlexWindow is not an inheritance of Component class
    // because it doesn't need ShowTitle().

    public class FlexWindow : BaseGUI
    {
        #region Field

        private Rect  _value;
        private float _previousShowTime;

        #endregion Field

        #region Property

        public Vector2 Position
        {
            get => new (_value.x, _value.y);
            set { _value.x = value.x; _value.y = value.y; }
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

        public FlexWindow() { }

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

            ID          = Guid.NewGuid().GetHashCode();
            MinWidth    = XGUILayout.DefaultWindowMinWidth;
            MinHeight   = XGUILayout.DefaultWindowMinHeight;
            MaxWidth    = XGUILayout.DefaultWindowMaxWidth;
            MaxHeight   = XGUILayout.DefaultWindowMaxHeight;
            IsDraggable = XGUILayout.DefaultWindowIsDraggable;
            IsVisible   = XGUILayout.DefaultWindowIsVisible;
        }

        public Rect Show(params Action[] guiAction)
        {
            if (!IsVisible)
            {
                return new Rect(_value.position.x, _value.position.y, 0, 0);
            }

            void WindowFunction(int windowID)
            {
                foreach (var action in guiAction)
                {
                    action();
                }

                if (IsDraggable)
                {
                    GUI.DragWindow();
                }
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

            if (_previousShowTime != Time.timeSinceLevelLoad)
            {
                _value            = new Rect(_value.x, _value.y, 0, 0);
                _previousShowTime = Time.timeSinceLevelLoad;
            }

            _value = GUILayout.Window(ID,
                                     _value,
                                     WindowFunction,
                                     base.Title,
                                     GUILayout.MinWidth (MinWidth),
                                     GUILayout.MinHeight(MinHeight),
                                     GUILayout.MaxWidth (MaxWidth),
                                     GUILayout.MaxHeight(MaxHeight));

            return _value;
        }

        #endregion Method
    }
}