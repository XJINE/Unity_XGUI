using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2sGUI : FieldGUIComponents<Vector2>
    {
        #region Constructor

        public Vector2sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector2sGUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector2(base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector2(base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
                Value     = (IList<Vector2>)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<Vector2> values = new List<Vector2>();

            for (int i = 0; i < tempValues.Length; i += 2)
            {
                values.Add(new Vector2(float.Parse(tempValues[i]),
                                       float.Parse(tempValues[i + 1])));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<Vector2>(values);
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
                       + base.gui.Value[i].y.ToString("G") + ",";
            }

            return value.TrimEnd(',');
        }

        #endregion Method
    }
}