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
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = base.guiInfo.MinValue,
                MaxValue  = base.guiInfo.MaxValue,
                Decimals  = base.guiInfo.Decimals,
                Value = (IList<float>)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<float> values = new List<float>();

            for (int i = 0; i < tempValues.Length; i++)
            {
                values.Add(float.Parse(tempValues[i]));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<float>(values);
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