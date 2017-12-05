using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIComponents
{
    public class Vector2GUI : FieldGUIComponent<Vector2>
    {
        #region Constructor

        public Vector2GUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector2GUI()
            {
                Value = (Vector2)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = new Vector2(base.attribute.MinValue, base.attribute.MinValue),
                MaxValue = new Vector2(base.attribute.MaxValue, base.attribute.MaxValue),
                Decimals = base.attribute.Decimals,
            };
        }

        #endregion Method
    }
}