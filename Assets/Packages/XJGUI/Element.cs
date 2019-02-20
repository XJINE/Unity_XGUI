using UnityEngine;

namespace XJGUI
{
    public abstract class Element<T> : Component<T>
    {
        #region Property

        // CAUTION:
        // "TitleColor" must be used for notification, not for design.

        public virtual Color? TitleColor { get; set; }

        protected override GUIStyle TitleStyle
        {
            get
            {
                GUIStyle style = base.TitleStyle;

                style.normal.textColor
                = TitleColor == null ? GUI.skin.label.normal.textColor
                                     : (Color)TitleColor;

                return style;
            }
        }

        #endregion Property

        #region Method

        public abstract T Show();

        #endregion Method
    }
}