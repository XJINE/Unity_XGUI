using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XGUI
{
    public class Selection<T> : Element<T>
    {
        #region Property

        protected Type Type { get; private set; }

        #endregion Property

        #region Constructor

        public Selection() : base() { }

        public Selection(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            this.Type = typeof(T);
        }

        public override T Show(T value)
        {
            base.ShowTitle();

            if (this.Type.IsEnum)
            {
                return Show(value, Enum.GetValues(this.Type).Cast<T>().ToArray());
            }
            else
            {
                return value;
            }
        }

        public virtual T Show(T value, IList<T> values, int xCount = 0)
        {
            base.ShowTitle();

            int index = Mathf.Max(0, values.IndexOf(value));

            xCount = xCount > 0 ? xCount : values.Count;

            if (this.Type == typeof(string))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<string>().ToArray(), xCount);
            }
            else if (this.Type == typeof(GUIContent))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<GUIContent>().ToArray(), xCount);
            }
            else if (this.Type == typeof(Texture))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<Texture>().ToArray(), xCount);
            }
            else
            {
                index = GUILayout.SelectionGrid(index, values.Select(x => x.ToString()).ToArray(), xCount);
            }

            return values[index];
        }

        #endregion Method
    }
}