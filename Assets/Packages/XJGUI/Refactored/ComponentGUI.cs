using UnityEngine;

namespace XJGUI
{
    public abstract class ComponentGUI<T> : BaseGUI<T>
    {
        #region Property

        protected virtual GUIStyle TitleStyle
        {
            get { return new GUIStyle(GUI.skin.label); }
        }

        #endregion Property

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

            GUILayout.Label(base.Title, TitleStyle);
        }

        #endregion Method
    }
}