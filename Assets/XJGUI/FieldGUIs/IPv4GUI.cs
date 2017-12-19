using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IPv4GUI : FieldGUIComponent<string>
    {
        #region Constructor

        public IPv4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.IPv4GUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                Value     = base.fieldInfo.GetValue(base.data).ToString(),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            base.gui.Value = value;
        }

        public override string GetSyncValue()
        {
            return base.updated ? base.gui.Value : null;
        }

        #endregion Method
    }
}