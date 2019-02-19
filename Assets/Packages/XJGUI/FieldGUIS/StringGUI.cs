using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class StringGUI : FieldGUIComponent<string>
    {
        #region Constructor

        public StringGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.StringGUI()
            {
                Value     = (string)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                FieldWidth = base.guiInfo.FieldWidth,
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