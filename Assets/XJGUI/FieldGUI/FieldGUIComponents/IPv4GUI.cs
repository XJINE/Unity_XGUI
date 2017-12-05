using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class IPv4GUI : FieldGUIComponent<string>
    {
        #region Constructor

        public IPv4GUI(System.Object data, FieldInfo info, FieldGUIInfo attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.IPv4GUI()
            {
                Value = base.info.GetValue(base.data).ToString(),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
            };
        }

        #endregion Method
    }
}