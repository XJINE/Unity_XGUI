﻿using System.Collections.Generic;
using System.Reflection;

namespace XJGUI
{
    public abstract class FieldGUIComponents<T> : FieldGUIComponentBase<IList<T>> where T: struct
    {
        #region Constructor

        public FieldGUIComponents(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void Load()
        {
            base.Load();

            T[] previousValue = new T[this.gui.Value.Count];
            this.gui.Value.CopyTo(previousValue, 0);
            this.previousValue = previousValue;
        }

        protected override void ShowGUI()
        {
            this.gui.Show();

            base.updateIndex = CheckUpdate(this.gui.Value, base.previousValue);

            T[] previousValue = new T[this.gui.Value.Count];
            this.gui.Value.CopyTo(previousValue, 0);

            base.previousValue = previousValue;
        }

        protected override int CheckUpdate(IList<T> value1, IList<T> value2)
        {
            for (int i = 0; i < value1.Count; i++)
            {
                if (!value1[i].Equals(value2[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion Method
    }
}