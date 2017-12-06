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
                UpdateLabels();
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
            if (this.Values == null || this.Values.Count == 0)
            {
                GUILayout.Label("Values Has No Item.");
                //return DefaultValue.
            }

            if (this.Values.Count != this.labels.Length)
            {
                UpdateLabels();
            }

            if (base.Value == null)
            {
                base.Value = this.Values[0];
            }

            XJGUILayout.VerticalLayout(()=>
            {
                int index = 0;
                int gridx = this.GridX <= 0 ? this.Values.Count : this.GridX;

                if (this.Foldout)
                {
                    this.foldoutPanel.Show(() => 
                    {
                        index = GUILayout.SelectionGrid(values.IndexOf(base.Value), this.labels, gridx);
                    });
                }
                else
                {
                    base.ShowTitle();

                    index = GUILayout.SelectionGrid(values.IndexOf(base.Value), this.labels, gridx);
                }

                base.Value = this.Values[index];
            });

            return base.Value;
        }

        protected void UpdateLabels()
        {
            if (this.Values != null)
            {
                int valuesCount = this.Values.Count;
                this.labels = new string[valuesCount];

                for (int i = 0; i < valuesCount; i++)
                {
                    this.labels[i] = this.Values[i].ToString();
                }
            }
        }

        #endregion Method
    }
}