namespace XJGUI
{
    public class IPv4sGUI : ElementsGUI<string>
    {
        #region Method

        protected override ElementGUI<string> GenerateGUI()
        {
            return new IPv4GUI();
        }

        #endregion Method
    }
}