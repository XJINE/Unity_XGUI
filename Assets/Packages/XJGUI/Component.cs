using UnityEngine;

namespace XJGUI
{
    public abstract class Component<T> : BaseGUI<T>
    {
        #region Property

        protected virtual GUIStyle TitleStyle
        {
            get { return new GUIStyle(GUI.skin.label); }
        }

        #endregion Property

        #region Constructor

        public Component() : base() { }

        public Component(string title) : base(title) { }

        public Component(string title, T value) : base(title, value) { }

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