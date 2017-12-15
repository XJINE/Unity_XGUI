using UnityEngine;

namespace XJGUI
{
    public abstract class ComponentGUI<T> : BaseGUI<T>
    {
        #region Field

        private static GUIStyle TitleStyle;

        protected bool boldTitle;

        #endregion Filed

        #region Property

        public virtual bool BoldTitle
        {
            get { return this.boldTitle; }
            set { this.boldTitle = value; }
        }

        #endregion Property

        #region Constructor

        public ComponentGUI()
        {
            this.boldTitle = false;
        }

        #endregion Constructor

        #region Method

        protected virtual void ShowTitle(bool setDummyTitle = false)
        {
            // NOTE:
            // Sometimes need to set dummy title to align another component to right.

            if (setDummyTitle)
            {
                this.Title = "";
            }

            if (this.Title == null)
            {
                return;
            }

            if (TitleStyle == null)
            {
                TitleStyle = new GUIStyle(GUI.skin.label);
            }

            TitleStyle.fontStyle = this.boldTitle ? FontStyle.Bold : FontStyle.Normal;

            GUILayout.Label(this.Title, TitleStyle);
        }

        #endregion Method
    }
}