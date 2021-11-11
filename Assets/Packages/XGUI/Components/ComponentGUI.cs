using UnityEngine;

namespace XGUI
{
    public abstract class ComponentGUI : BaseGUI
    {
        #region Property

        // NOTE:
        // GUIStyle and GUI.skin are accessible in OnGUI().

        private   static GUIStyle _titleStyle;
        protected static GUIStyle TitleStyle
        {
            get
            {
                _titleStyle ??= new GUIStyle(GUI.skin.label);
                return _titleStyle;
            }
        }

        #endregion Property

        #region Constructor

        protected ComponentGUI() { }

        protected ComponentGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected virtual void ShowTitle(bool blank = false)
        {
            // NOTE:
            // Sometimes need to set empty(dummy) title to align another component to right.

            const string emptyTitle = "";

            if (!blank && string.IsNullOrEmpty(base.Title))
            {
                return;
            }

            GUILayout.Label(blank ? emptyTitle : base.Title, TitleStyle);
        }

        #endregion Method
    }
}