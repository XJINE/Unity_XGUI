using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XGUI
{
    public class SelectionGrid<T> : SelectionElement<T>
    {
        #region Field

        public virtual int GridX { get; set; } = -1;

        #endregion Field

        #region Constructor

        public SelectionGrid() : base() { }

        public SelectionGrid(string title) : base(title) { }

        public SelectionGrid(string title, int gridX) : base(title)
        {
            this.GridX = gridX;
        }

        #endregion Constructor

        #region Method

        public override T Show(T value, IList<T> values)
        {
            base.ShowTitle();

            int gridX = this.GridX <= 0 ? values.Count : this.GridX;

            int index = Mathf.Max(0, values.IndexOf(value));

            if (this.Type == typeof(string))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<string>().ToArray(), gridX);
            }
            else if (this.Type == typeof(GUIContent))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<GUIContent>().ToArray(), gridX);
            }
            else if (this.Type == typeof(Texture))
            {
                index = GUILayout.SelectionGrid(index, values.Cast<Texture>().ToArray(), gridX);
            }
            else
            {
                index = GUILayout.SelectionGrid(index, values.Select(x => x.ToString()).ToArray(), gridX);
            }

            return values[index];
        }

        #endregion Method
    }
}