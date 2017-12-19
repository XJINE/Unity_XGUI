using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public abstract class ElementsGUI<T> : ElementGUI<IList<T>>
    {
        #region Field

        protected ElementGUI<T>[] guis;
        protected FoldoutPanel foldOutPanel;

        #endregion Field

        #region Property

        public override IList<T> Value
        {
            get
            {
                return base.value;
            }
            set
            {
                base.value = value;

                if (base.value != null)
                {
                    UpdateGUIs();
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
                this.foldOutPanel.Title = value;
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
                this.foldOutPanel.BoldTitle = value;
            }
        }

        #endregion Property

        #region Constructor

        public ElementsGUI() : base()
        {
            // NOTE:
            // base.title & base.boldTitle is initialized in base() constructor.

            this.foldOutPanel = new FoldoutPanel()
            {
                Title = base.title,
                BoldTitle = base.boldTitle,
                Value = false
            };
        }

        #endregion Consctructor

        #region Method

        public override IList<T> Show()
        {
            if (this.Value != null && this.guis.Length != this.Value.Count)
            {
                UpdateGUIs();
            }

            XJGUILayout.VerticalLayout(() => 
            {
                if (this.Title != null)
                {
                    this.foldOutPanel.Show(delegate ()
                    {
                        ShowComponentGUI();
                    });
                }
                else
                {
                    ShowComponentGUI();
                }
            });

            return this.Value;
        }

        protected void ShowComponentGUI()
        {
            if (this.Value == null)
            {
                GUILayout.Label("Null");
                return;
            }

            int valueCount = this.Value.Count;

            if (valueCount == 0)
            {
                GUILayout.Label("No Element");
                return;
            }

            for (int i = 0; i < valueCount; i++)
            {
                this.Value[i] = this.guis[i].Show();
            }
        }

        internal override void SetTitleColor(Color? titleColor)
        {
            base.SetTitleColor(titleColor);

            if (this.foldOutPanel != null)
            {
                this.foldOutPanel.SetTitleColor(titleColor);
            }
        }

        protected virtual void UpdateGUIs()
        {
            int valueCount = this.Value.Count;
            this.guis = new ElementGUI<T>[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                ElementGUI<T> gui = GenerateGUI();
                gui.Value = this.Value[i];
                InitializeGUI(gui);
                this.guis[i] = gui;
            }
        }

        protected abstract ElementGUI<T> GenerateGUI();

        protected virtual void InitializeGUI(ElementGUI<T> gui)
        {
            gui.BoldTitle = false;
        }

        #endregion Method
    }
}