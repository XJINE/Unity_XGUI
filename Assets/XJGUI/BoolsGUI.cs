namespace XJGUI
{
    public class BoolsGUI : ElementsGUI<bool>
    {
        #region Method

        protected override ElementGUI<bool> GenerateGUI()
        {
            return new BoolGUI();
        }

        #endregion Method
    }
}