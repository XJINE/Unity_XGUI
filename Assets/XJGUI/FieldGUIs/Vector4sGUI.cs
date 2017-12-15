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
                Value     = (IList<Vector4>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector4(base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector4(base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            string[] values = value.Split(',');
            ((ValuesGUI<Vector4>)base.gui).SetValue(index, new Vector4()
            {
                x = float.Parse(values[0]),
                y = float.Parse(values[1]),
                z = float.Parse(values[2]),
                w = float.Parse(values[3]),
            });
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].x.ToString("G") + ","
                                     + base.gui.Value[index].y.ToString("G") + ","
                                     + base.gui.Value[index].z.ToString("G") + ","
                                     + base.gui.Value[index].w.ToString("G");
        }

        #endregion Method
    }
}