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
                Value = (Vector2)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector2(base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue = new Vector2(base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(Vector2 value1, Vector2 value2)
        {
            return value1 == value2 ? -1 : 0;
        }

        #endregion Method
    }
}