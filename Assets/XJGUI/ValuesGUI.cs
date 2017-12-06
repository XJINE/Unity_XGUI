using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public abstract class ValuesGUI<T> : ElementBaseGUI<IList<T>> where T : struct
    {
        #region Field

        protected ValueGUI<T>[] valueGUIs;
        protected FoldoutPanel foldOutPanel;

        protected T minValue;
        protected T maxValue;
        protected int decimals;
        protected float textFieldWidth;
        protected bool withSlider;

        #endregion Field

        #region Property

        // NOTE:
        // Some properties initialized by base() constructor.
        // So need null check.

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

        public virtual int Decimals
        {
            get
            {
                return this.decimals;
            }
            set
            {
                this.decimals = value;

                if (base.value == null || CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].Decimals = value;
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

            this.decimals = 2;
            this.textFieldWidth = 0;
            this.withSlider = true;
        }

        #endregion Constructor

        #region Method

        public override IList<T> Show()
        {
            if (this.Value != null)
            {
                CheckValueGUIsUpdate();
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
                GUILayout.Label("NULL");
                return;
            }

            int valueCount = this.Value.Count;

            if (valueCount == 0)
            {
                GUILayout.Label("NO ELEMENT");
                return;
            }

            for (int i = 0; i < valueCount; i++)
            {
                this.Value[i] = this.valueGUIs[i].Show();
            }
        }

        protected bool CheckValueGUIsUpdate()
        {
            int valueCount = this.Value.Count;

            if (this.valueGUIs != null && this.valueGUIs.Length == this.Value.Count)
            {
                return false;
            }

            this.valueGUIs = new ValueGUI<T>[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                this.valueGUIs[i] = GenerateValueGUI();
                this.valueGUIs[i].Value = this.Value[i];
            }

            return true;
        }

        protected abstract ValueGUI<T> GenerateValueGUI();

        #endregion Method
    }
}