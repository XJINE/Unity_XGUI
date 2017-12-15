namespace XJGUI
{
    public class BoolsGUI : ElementsGUI<bool>
    {
        #region Method

        protected override ElementGUI<bool> GenerateValueGUI()
        {
            return new BoolGUI();
        }

        #endregion Method
    }
}