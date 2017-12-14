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
                Value = (string)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle
            };
        }

        protected override int CheckUpdate(string value1, string value2)
        {
            return value1 == value2 ? -1 : 0;
        }

        #endregion Method
    }
}