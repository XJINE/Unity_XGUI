using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntsGUI : FieldGUIComponents<int>
    {
        #region Constructor

        public IntsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.IntsGUI()
            {
                Value     = (IList<int>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = (int)base.guiInfo.MinValue,
                MaxValue  = (int)base.guiInfo.MaxValue,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            ((ValuesGUI<int>)base.gui).SetValue(index, int.Parse(value));
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].ToString("G");
        }

        #endregion Method
    }
}