using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XGUI
{
    public class Toolbar<T> : SelectionElement<T>
    {
        #region Constructor

        public Toolbar() : base() { }

        public Toolbar(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override T Show(T value, IList<T> values)
        {
            base.ShowTitle();

            int index = Mathf.Max(0, values.IndexOf(value));

            if (this.Type == typeof(string))
            {
                index = GUILayout.Toolbar(index, values.Cast<string>().ToArray());
            }
            else if (this.Type == typeof(GUIContent))
            {
                index = GUILayout.Toolbar(index, values.Cast<GUIContent>().ToArray());
            }
            else if (this.Type == typeof(Texture))
            {
                index = GUILayout.Toolbar(index, values.Cast<Texture>().ToArray());
            }
            else
            {
                index = GUILayout.Toolbar(index, values.Select(x => x.ToString()).ToArray());
            }

            return values[index];
        }

        #endregion Method
    }
}