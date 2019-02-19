using System;
using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class EnumsGUI<T> : FieldGUIComponents<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Constructor

        public EnumsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.EnumsGUI<T>()
            {
                Value     = (IList<T>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] tempValues = value.Split(',');

            List<T> values = new List<T>();

            for (int i = 0; i < tempValues.Length; i++)
            {
                values.Add((T)Enum.Parse(typeof(T), tempValues[i]));
            }

            if (base.gui.Value.GetType().IsArray)
            {
                base.gui.Value = values.ToArray();
            }
            else
            {
                base.gui.Value = new List<T>(values);
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