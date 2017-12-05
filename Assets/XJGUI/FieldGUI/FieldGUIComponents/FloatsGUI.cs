using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class FloatsGUI : FieldGUIComponent<IList<float>>
    {
        #region Constructor

        public FloatsGUI(System.Object data, FieldInfo info, FieldGUIAttribute attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.FloatsGUI()
            {
                Value = (IList<float>)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = base.attribute.MinValue,
                MaxValue = base.attribute.MaxValue,
            };
        }

        #endregion Method
    }
}