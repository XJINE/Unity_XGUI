namespace XJGUI
{
    // NOTE: T must be Vector2, 3, 4.

    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Property

        public virtual int Decimals
        {
            get; set;
        }

        public virtual bool Horizontal
        {
            get; set;
        }

        #endregion Property

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
    }
}