using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector4sGUI : FieldGUIComponents<Vector4>
    {
        #region Constructor

        public Vector4sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector4sGUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector4(base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector4(base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
                Value     = (IList<Vector4>)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<Vector4> values = new List<Vector4>();

            for (int i = 0; i < tempValues.Length; i += 4)
            {
                values.Add(new Vector4(float.Parse(tempValues[i]),
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
                base.gui.Value = new List<Vector4>(values);
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
                value += base.gui.Value[i].x.ToString("G") + ","
                       + base.gui.Value[i].y.ToString("G") + ","
                       + base.gui.Value[i].z.ToString("G") + ","
                       + base.gui.Value[i].w.ToString("G") + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}