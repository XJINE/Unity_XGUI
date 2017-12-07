using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class StringGUI : FieldGUIComponent<string>
    {
        #region Constructor

        public StringGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
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

        #endregion Method
    }
}