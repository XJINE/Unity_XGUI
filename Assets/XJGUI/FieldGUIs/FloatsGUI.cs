using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatsGUI : FieldGUIComponents<float>
    {
        #region Constructor

        public FloatsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.FloatsGUI()
            {
                Value     = (IList<float>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = base.guiInfo.MinValue,
                MaxValue  = base.guiInfo.MaxValue,
                Decimals  = base.guiInfo.Decimals,
            };
        }

        #endregion Method
    }
}