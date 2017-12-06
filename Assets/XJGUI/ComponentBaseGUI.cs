using UnityEngine;

namespace XJGUI
{
    public abstract class ComponentBaseGUI<T> : BaseGUI<T>
    {
        #region Field

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

        public ComponentBaseGUI()
        {
            this.boldTitle = false;
        }

        #endregion Constructor

        #region Method

        protected virtual void ShowTitle()
        {
            if (this.Title == null)
            {
                return;
            }

            if (this.BoldTitle)
            {
                XJGUILayout.BoldLabel(this.Title);
            }
            else
            {
                GUILayout.Label(this.Title);
            }
        }

        #endregion Method
    }
}