using UnityEngine;

namespace XJGUI
{
    public class BaseGUI<T>
    {
        #region Field

        protected T value;
        protected string title;
        protected bool boldTitle;

        #endregion Field

        #region Property

        public virtual T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

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