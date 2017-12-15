using System;
using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class BoolsGUI : FieldGUIComponents<bool>
    {
        #region Constructor

        public BoolsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.BoolsGUI()
            {
                Value     = (IList<bool>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            ((ElementsGUI<bool>)base.gui).SetValue(index, Convert.ToBoolean(value));
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].ToString();
        }

        #endregion Method
    }
}