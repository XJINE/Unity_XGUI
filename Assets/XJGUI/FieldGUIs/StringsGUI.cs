using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class StringsGUI : FieldGUIComponents<string>
    {
        #region Constructor

        public StringsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.StringsGUI()
            {
                Value     = (IList<string>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                TextFieldWidth = base.guiInfo.FieldWidth,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            ((ElementsGUI<string>)base.gui).SetValue(index, value);
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index];
        }

        #endregion Method
    }
}