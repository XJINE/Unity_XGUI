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
                Value     = (IList<Vector2>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = new Vector2(base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue  = new Vector2(base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals  = base.guiInfo.Decimals,
            };
        }

        #endregion Method
    }
}