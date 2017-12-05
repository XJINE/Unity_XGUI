using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public abstract class ValuesGUI<T> : ComponentBaseGUI<IList<T>> where T : struct
    {
        #region Field

        protected ValueGUI<T>[] valueGUIs;
        protected FoldoutPanel foldOutPanel;

        protected T minValue;
        protected T maxValue;
        protected float textFieldWidth;
        protected bool withSlider;

        #endregion Field

        #region Property

        // NOTE:
        // Some properties initialized by base() constructor.

        public override string Title
        {
            get
            {
                return base.title;
            }
            set
            {
                base.title = value;

                if (this.foldOutPanel != null)
                {
                    this.foldOutPanel.Title = value;
                }
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

                if (this.foldOutPanel != null)
                {
                    this.foldOutPanel.BoldTitle = value;
                }
            }
        }

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
                    CheckValueGUIsUpdate();
                }
            }
        }

        public virtual T MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;

                if (base.value == null || CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].MinValue = value;
                }
            }
        }

        public virtual T MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;

                if (base.value == null || CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].MaxValue = value;
                }
            }
        }

        public virtual float TextFieldWidth
        {
            get
            {
                return this.textFieldWidth;
            }
            set
            {
                this.textFieldWidth = value;

                if (base.value == null || CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].TextFieldWidth = value;
                }
            }
        }

        public virtual bool WithSlider
        {
            get
            {
                return this.withSlider;
            }
            set
            {
                this.withSlider = value;

                if (base.value == null || CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].WithSlider = value;
                }
            }
        }

        #endregion Property

        #region Constructor

        public ValuesGUI() : base()
        {
            this.foldOutPanel = new FoldoutPanel()
            {
                Title     = base.title,
                BoldTitle = base.boldTitle,
                Value     = false
            };

            this.textFieldWidth = 0;
            this.withSlider = true;
        }

        #endregion Constructor

        #region Method

        public override IList<T> Show()
        {
            if (base.value != null)
            {
                CheckValueGUIsUpdate();
            }

            XJGUILayout.VerticalLayout(() =>
            {
                if (base.title != null)
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

            return base.value;
        }

        protected void ShowComponentGUI()
        {
            if (base.value == null)
            {
                GUILayout.Label("NULL");
                return;
            }

            int valueCount = base.value.Count;

            if (valueCount == 0)
            {
                GUILayout.Label("NO ELEMENT");
                return;
            }

            for (int i = 0; i < valueCount; i++)
            {
                base.value[i] = valueGUIs[i].Show();
            }
        }

        protected bool CheckValueGUIsUpdate()
        {
            int valueCount = base.value.Count;

            if (this.valueGUIs != null && base.value.Count == this.valueGUIs.Length)
            {
                return false;
            }

            this.valueGUIs = new ValueGUI<T>[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                this.valueGUIs[i] = GenerateValueGUI();
                this.valueGUIs[i].Value = base.value[i];
            }

            return true;
        }

        protected abstract ValueGUI<T> GenerateValueGUI();

        #endregion Method
    }
}