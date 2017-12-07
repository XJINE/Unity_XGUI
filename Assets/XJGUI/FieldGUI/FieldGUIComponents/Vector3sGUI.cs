using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIComponents
{
    public class Vector3sGUI : FieldGUIComponent<IList<Vector3>>
    {
        #region Constructor

        public Vector3sGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector3sGUI()
            {
                Value = (IList<Vector3>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector3(base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue),
                MaxValue = new Vector3(base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        #endregion Method
    }
}