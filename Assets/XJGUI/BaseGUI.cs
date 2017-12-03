using UnityEngine;

namespace XJGUI
{
    public class BaseGUI<T>
    {
        #region Field

        protected T value;

        #endregion Field

        #region Property

        public string Title { get; set; }

        public bool BoldTitle { get; set; }

        public virtual T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion Property

        #region Constructor

        public BaseGUI()
        {
            this.Title = null;
            this.BoldTitle = false;
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