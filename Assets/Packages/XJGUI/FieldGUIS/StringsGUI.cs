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
                FieldWidth = base.guiInfo.FieldWidth,
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = tempValues;
            }
            else
            {
                base.gui.Value = new List<string>(tempValues);
            }
        }

        public override string GetSyncValue()
        {
            if (!base.updated)
            {
                return null;
            }

            string value = "";

            for (int i = 0; i < base.gui.Value.Count; i++)
            {
                value += base.gui.Value[i].ToString() + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}