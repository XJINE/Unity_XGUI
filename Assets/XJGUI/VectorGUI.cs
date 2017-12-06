namespace XJGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Field

        protected bool horizontal;

        #endregion Field

        #region Property

        public virtual bool Horizontal
        {
            get { return this.horizontal; }
            set { this.horizontal = value; }
        }

        #endregion Property

        #region Constructor

        public VectorGUI()
        {
            this.horizontal = true;
        }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            XJGUILayout.VerticalLayout((() =>
            {
                base.ShowTitle();

                if (this.Horizontal)
                {
                    XJGUILayout.HorizontalLayout(() =>
                    {
                        ShowComponentGUI();
                    });
                }
                else
                {
                    ShowComponentGUI();
                }
            }));

            return this.Value;
        }

        protected abstract void ShowComponentGUI();

        #endregion Method
    }
}