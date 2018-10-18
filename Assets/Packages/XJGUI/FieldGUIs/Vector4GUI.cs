using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector4GUI : FieldGUIComponent<Vector4>
    {
        #region Constructor

        public Vector4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector4GUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector4(base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector4(base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
                Value     = (Vector4)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            string[] values = value.Split(',');
            base.gui.Value = new Vector4()
            {
                x = float.Parse(values[0]),
                y = float.Parse(values[1]),
                z = float.Parse(values[2]),
                w = float.Parse(values[3]),
            };
        }

        public override string GetSyncValue()
        {
            return base.updated ? base.gui.Value.x.ToString("G") + ","
                                + base.gui.Value.y.ToString("G") + ","
                                + base.gui.Value.z.ToString("G") + ","
                                + base.gui.Value.w.ToString("G")
                                : null;
        }

        #endregion Method
    }
}