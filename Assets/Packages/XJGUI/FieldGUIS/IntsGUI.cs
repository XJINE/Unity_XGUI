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
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = (int)base.guiInfo.MinValue,
                MaxValue  = (int)base.guiInfo.MaxValue,
                Value     = (IList<int>)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<int> values = new List<int>();

            for (int i = 0; i < tempValues.Length; i++)
            {
                values.Add(int.Parse(tempValues[i]));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<int>(values);
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
                value += base.gui.Value[i].ToString("G") + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}