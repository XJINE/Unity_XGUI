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
            private set { this.titleColor = value; }
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
            TitleStyle.normal.textColor = this.TitleColor == null ?
                GUI.skin.label.normal.textColor : (Color)this.TitleColor;

            GUILayout.Label(this.Title, TitleStyle);
        }

        // CAUTION:
        // Mainly use for notification (Ex. Sync or Not), Must not use for design.

        // NOTE:
        // Consider to check called from FieldGUIBase or not.

        internal virtual void SetTitleColor(Color? titleColor)
        {
            this.titleColor = titleColor;
        }

        #endregion Method
    }
}