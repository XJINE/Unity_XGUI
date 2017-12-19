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

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<bool> values = new List<bool>();

            for (int i = 0; i < tempValues.Length; i++)
            {
                values.Add(Convert.ToBoolean(tempValues[i]));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<bool>(values);
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