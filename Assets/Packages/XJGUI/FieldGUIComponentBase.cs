using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public abstract class FieldGUIComponentBase<T> : FieldGUIBase
    {
        #region Field

        protected ElementGUI<T> gui;

        protected T previousValue;

        #endregion Field

        #region Constructor

        public FieldGUIComponentBase(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void Save()
        {
            base.fieldInfo.SetValue(base.data, this.gui.Value);
        }

        protected override void Load()
        {
            this.gui.Value = (T)base.fieldInfo.GetValue(base.data);
        }

        public override void SetTitleColor(Color? color)
        {
            this.gui.SetTitleColor(color);
        }

        protected abstract bool GetValueIsUpdated(T value1, T value2);

        #endregion Method
    }
}