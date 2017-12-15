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
                TextFieldWidth = base.guiInfo.FieldWidth,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            base.gui.Value = value;
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = base.gui.Value;
        }

        #endregion Method
    }
}