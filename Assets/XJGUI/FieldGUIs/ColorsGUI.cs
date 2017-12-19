using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class ColorsGUI : FieldGUIComponents<Color>
    {
        #region Constructor

        public ColorsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.ColorsGUI()
            {
                Value     = (IList<Color>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = base.guiInfo.MinColor,
                MaxValue  = base.guiInfo.MaxColor,
                Decimals  = base.guiInfo.Decimals,
                HSV       = base.guiInfo.HSV,
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<Color> values = new List<Color>();

            for (int i = 0; i < tempValues.Length; i += 4)
            {
                values.Add(new Color(float.Parse(tempValues[i]),
                                     float.Parse(tempValues[i + 1]),
                                     float.Parse(tempValues[i + 2]),
                                     float.Parse(tempValues[i + 3])));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<Color>(values);
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
                value += base.gui.Value[i].r.ToString("G") + ","
                       + base.gui.Value[i].g.ToString("G") + ","
                       + base.gui.Value[i].b.ToString("G") + ","
                       + base.gui.Value[i].a.ToString("G") + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}