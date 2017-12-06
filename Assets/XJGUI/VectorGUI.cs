namespace XJGUI
{
    public abstract class VectorGUI<T> : ValueGUI<T> where T : struct
    {
        #region Method

        public override T Show()
        {
            XJGUILayout.VerticalLayout(() =>
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() =>
                {
                    ShowComponentGUI();
                });
            });

            return this.Value;
        }

        protected abstract void ShowComponentGUI();

        #endregion Method
    }
}