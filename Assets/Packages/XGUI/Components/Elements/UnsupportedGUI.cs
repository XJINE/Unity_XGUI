namespace XGUI
{
    public class UnSupportedGUI : ElementGUI<int>
    {
        #region Constructor

        public UnSupportedGUI() { }

        public UnSupportedGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override int Show(int value)
        {
            XGUILayout.Label("UnSupported : " + base.Title);
            return -1;
        }

        #endregion Method
    }
}