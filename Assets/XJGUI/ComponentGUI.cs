using UnityEngine;

namespace XJGUI
{
    public abstract class ComponentGUI<T> : BaseGUI<T>
    {
        #region Field

        private static GUIStyle TitleStyle;

        protected bool boldTitle;

        protected Color? titleColor;

        #endregion Filed

        #region Property

        public virtual bool BoldTitle
        {
            get { return this.boldTitle; }
            set { this.boldTitle = value; }
        }

        protected virtual Color? TitleColor
        {
            get { return this.titleColor; }
            set { this.titleColor = value; }
        }

        #endregion Property

        #region Constructor

        public ComponentGUI()
        {
            this.boldTitle = XJGUILayout.DefaultBoldTitle;
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

            TitleStyle.normal.textColor = this.titleColor != null ?
               (Color)this.TitleColor : TitleStyle.normal.textColor;

            GUILayout.Label(this.Title, TitleStyle);
        }

        // CAUTION:
        // Mainly use for notification (Ex.Sync or Not), Don't use for design.

        internal virtual void SetTitleColor(Color? titleColor)
        {
            this.titleColor = titleColor;
        }

        #endregion Method
    }
}