using UnityEngine;

namespace XGUI
{
    public abstract class Component<T> : BaseGUI<T>
    {
        #region Property

        // NOTE:
        // GUIStyle and GUI.skin are accessible in OnGUI().

        private   static GUIStyle titleStyle;
        protected static GUIStyle TitleStyle
        {
            get
            {
                titleStyle = titleStyle ?? new GUIStyle(GUI.skin.label);
                return titleStyle;
            }
        }

        #endregion Property

        #region Constructor

        public Component() : base() { }

        public Component(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected virtual void ShowTitle(bool blank = false)
        {
            // NOTE:
            // Sometimes need to set dummy title to align another component to right.

            if (blank)
            {
                base.Title = "";
            }

            if (base.Title == null)
            {
                return;
            }

            GUILayout.Label(base.Title, TitleStyle);
        }

        #endregion Method
    }
}