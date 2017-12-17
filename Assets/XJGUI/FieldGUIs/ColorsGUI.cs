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

        public override void SetSyncValue(int index, string value)
        {
            string[] values = value.Split(',');
            ((ValuesGUI<Color>)base.gui).SetValue(index, new Color()
            {
                r = float.Parse(values[0]),
                g = float.Parse(values[1]),
                b = float.Parse(values[2]),
                a = float.Parse(values[3]),
            });
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].r.ToString("G") + ","
                                     + base.gui.Value[index].g.ToString("G") + ","
                                     + base.gui.Value[index].b.ToString("G") + ","
                                     + base.gui.Value[index].a.ToString("G");
        }

        #endregion Method
    }
}