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

        public override void SetSyncValue(int index, string value)
        {
            string[] values = value.Split(',');
            ((ValuesGUI<Vector2>)base.gui).SetValue(index, new Vector2()
            {
                x = float.Parse(values[0]),
                y = float.Parse(values[1])
            });
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].x.ToString("G") + ","
                                     + base.gui.Value[index].y.ToString("G");
        }

        #endregion Method
    }
}