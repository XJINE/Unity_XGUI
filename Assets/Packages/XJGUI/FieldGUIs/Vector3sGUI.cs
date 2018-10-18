using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3sGUI : FieldGUIComponents<Vector3>
    {
        #region Constructor

        public Vector3sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector3sGUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector3(base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector3(base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
                Value     = (IList<Vector3>)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<Vector3> values = new List<Vector3>();

            for (int i = 0; i < tempValues.Length; i += 3)
            {
                values.Add(new Vector3(float.Parse(tempValues[i]),
                                       float.Parse(tempValues[i + 1]),
                                       float.Parse(tempValues[i + 2])));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<Vector3>(values);
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
                       + base.gui.Value[i].z.ToString("G") + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}