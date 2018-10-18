using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public class Toolbar<T> : ElementGUI<T>
    {
        #region Field

        IList<T> values;

        protected string[] labels;

        protected FoldoutPanel foldoutPanel;

        protected bool foldout;

        protected int gridX;

        #endregion Field

        #region Property

        public override T Value
        {
            get
            {
                return base.value;
            }
            set
            {
                if (this.values == null)
                {
                    base.value = value;
                }
                else
                {
                    base.value = this.Values.IndexOf(value) == -1 ?
                                 this.Values[0] : value;
                }
            }
        }

        public override string Title
        {
            get
            {
                return base.title;
            }

            set
            {
                base.title = value;
                this.foldoutPanel.Title = value;
            }
        }

        public override bool BoldTitle
        {
            get
            {
                return base.boldTitle;
            }

            set
            {
                base.boldTitle = value;
                this.foldoutPanel.BoldTitle = value;
            }
        }

        public IList<T> Values
        {
            get
            {
                return this.values;
            }
            set
            {
                this.values = value;

                if (this.values == null)
                {
                    base.value = default(T);
                }
                else
                {
                    base.value = this.values.IndexOf(base.value) == -1 ?
                                 this.values[0] : base.value;
                    UpdateLabels();
                }
            }
        }

        public bool Foldout { get; set; }

        public int GridX { get; set; }

        #endregion Property

        #region Constructor

        public Toolbar() : base()
        {
            this.foldoutPanel = new FoldoutPanel()
            {
                Title = base.title,
                BoldTitle = base.boldTitle,
                Value = false
            };
        }

        #endregion Constructor

        #region Method

        public override T Show()
        {
            if (this.values == null || this.values.Count == 0)
            {
                GUILayout.Label("Values has no item. Return value shows default.");

                base.value = default(T);

                return default(T);
            }

            int index = this.values.IndexOf(base.value);

            if (base.value == null || index == -1)
            {
                index = 0;
                base.value = this.values[0];
            }

            if (this.values.Count != this.labels.Length)
            {
                UpdateLabels();
            }

            XJGUILayout.VerticalLayout(()=>
            {
                int gridx = this.GridX <= 0 ? this.values.Count : this.GridX;

                if (this.Foldout)
                {
                    this.foldoutPanel.Show(() => 
                    {
                        index = GUILayout.SelectionGrid(index, this.labels, gridx);
                    });
                }
                else
                {
                    base.ShowTitle();

                    index = GUILayout.SelectionGrid(index, this.labels, gridx);
                }

                base.value = this.values[index];
            });

            return base.value;
        }

        protected void UpdateLabels()
        {
            int valuesCount = this.Values.Count;
            this.labels = new string[valuesCount];

            for (int i = 0; i < valuesCount; i++)
            {
                if (typeof(T).IsClass)
                {
                    this.labels[i] = this.Values[i].GetType().Name + i;
                }
                else
                {
                    this.labels[i] = this.Values[i].ToString();
                }
            }
        }

        #endregion Method
    }
}