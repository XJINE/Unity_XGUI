using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIComponents
{
    public class Vector4sGUI : FieldGUIComponent<IList<Vector4>>
    {
        #region Constructor

        public Vector4sGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector4sGUI()
            {
                Value = (IList<Vector4>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector4(base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue),
                MaxValue = new Vector4(base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        #endregion Method
    }
}