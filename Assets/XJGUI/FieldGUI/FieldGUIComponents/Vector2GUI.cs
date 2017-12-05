using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIComponents
{
    public class Vector2GUI : FieldGUIComponent<Vector2>
    {
        #region Constructor

        public Vector2GUI(System.Object data, FieldInfo info, FieldGUIAttribute attribute)
            : base(data, info, attribute)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new global::XJGUI.Vector2GUI()
            {
                Value = (Vector2)base.info.GetValue(base.data),
                Title = base.attribute.Title,
                BoldTitle = base.attribute.BoldTitle,
                MinValue = (Vector2)base.attribute.MinValue,
                MaxValue = (Vector2)base.attribute.MaxValue,
            };
        }

        #endregion Method
    }
}