using UnityEngine;

namespace XJGUI
{
    public class BaseGUI<T>
    {
        #region Field

        protected string title;
        protected bool boldTitle;
        protected T value;

        #endregion Field

        #region Property

        public virtual string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public virtual bool BoldTitle
        {
            get { return this.boldTitle; }
            set { this.boldTitle = value; }
        }

        public virtual T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion Property

        #region Constructor

        public BaseGUI()
        {
            this.title = null;
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