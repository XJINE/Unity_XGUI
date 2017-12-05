using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class IntsGUI : FieldGUIComponent<IList<int>>
    {
        #region Constructor

        public IntsGUI(System.Object data, FieldInfo info, FieldGUIAttribute attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.IntsGUI()
            {
                Value = (IList<int>)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = (int)base.attribute.MinValue,
                MaxValue = (int)base.attribute.MaxValue,
            };
        }

        #endregion Method
    }
}