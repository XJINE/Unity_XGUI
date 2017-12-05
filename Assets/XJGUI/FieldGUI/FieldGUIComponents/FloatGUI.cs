using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class FloatGUI : FieldGUIComponent<float>
    {
        #region Constructor

        public FloatGUI(System.Object data, FieldInfo info, FieldGUIInfo attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.FloatGUI()
            {
                Value = (float)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = base.attribute.MinValue,
                MaxValue = base.attribute.MaxValue,
            };
        }

        #endregion Method
    }
}