using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XGUIs
{
    public class Selection<T> : ElementGUI<T>
    {
        #region Property

        protected Type Type { get; private set; }

        #endregion Property

        #region Constructor

        public Selection() { }

        public Selection(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            Type = typeof(T);
        }

        public override T Show(T value)
        {
            base.ShowTitle();

            if (Type.IsEnum)
            {
                return Show(value, Enum.GetValues(Type).Cast<T>().ToArray());
            }

            return value;
        }

        public virtual T Show(T value, IList<T> values, int xCount = 0)
        {
            base.ShowTitle();

            var index = Mathf.Max(0, values.IndexOf(value));

            xCount = xCount > 0 ? xCount : values.Count;

            if (Type == typeof(string))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<string>().ToArray(), xCount);
            }
            else if (Type == typeof(GUIContent))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<GUIContent>().ToArray(), xCount);
            }
            else if (Type == typeof(Texture))
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