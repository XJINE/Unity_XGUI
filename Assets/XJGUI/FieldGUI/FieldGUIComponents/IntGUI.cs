using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class IntGUI : FieldGUIComponent<int>
    {
        #region Constructor

        public IntGUI(System.Object data, FieldInfo info, FieldGUIInfo attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.IntGUI()
            {
                Value = (int)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = (int)base.attribute.MinValue,
                MaxValue = (int)base.attribute.MaxValue,
            };
        }

        #endregion Method
    }
}