using UnityEngine;

namespace XJGUI
{
    public abstract class ComponentGUI<T> : BaseGUI<T>
    {
        #region Property

        // CAUTION:
        // "TitleColor" must be used for notification, not for design.

        public virtual bool   BoldTitle  { get; set; }
        public virtual Color? TitleColor { get; set; }

        #endregion Property

        #region Constructor

        public ComponentGUI() : base()
        {
            this.BoldTitle = XJGUILayout.DefaultBoldTitle;
        }

        #endregion Constructor

        #region Method

        protected virtual void ShowTitle(bool dummyTitle = false)
        {
            // NOTE:
            // Sometimes need to set dummy title to align another component to right.

            if (dummyTitle)
            {
                base.Title = "";
            }

            if (base.Title == null)
            {
                return;
            }

            GUILayout.Label(base.Title, GetTitleStyle());
        }

        protected GUIStyle GetTitleStyle()
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                fontStyle = this.BoldTitle ? FontStyle.Bold : FontStyle.Normal
            };

            style.normal.textColor = this.TitleColor == null ? GUI.skin.label.normal.textColor
                                                             : (Color)this.TitleColor;

            return style;
        }

        #endregion Method
    }
}