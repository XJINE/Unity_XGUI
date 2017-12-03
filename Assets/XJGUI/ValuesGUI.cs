using System.Collections.Generic;

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

        public virtual T MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;

                if (CheckValueGUIsUpdate())
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

                if (CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].MaxValue = value;
                }
            }
        }

        public float TextFieldWidth
        {
            get
            {
                return this.textFieldWidth;
            }
            set
            {
                this.textFieldWidth = value;

                if (CheckValueGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    this.valueGUIs[i].TextFieldWidth = value;
                }
            }
        }

        public bool WithSlider
        {
            get
            {
                return this.withSlider;
            }
            set
            {
                this.withSlider = value;

                if (CheckValueGUIsUpdate())
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
            this.foldOutPanel = new FoldoutPanel();

            if (base.value != null)
            {
                for (int i = 0; i < this.value.Count; i++)
                {
                    this.valueGUIs[i] = GenerateValueGUI();
                }
            }
        }

        #endregion Constructor

        #region Method

        public override IList<T> Show()
        {
            if (this.value == null)
            {
                return null;
            }

            XJGUILayout.VerticalLayout(() =>
            {
                if (base.Title != null)
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
            CheckValueGUIsUpdate();

            for (int i = 0; i < base.value.Count; i++)
            {
                base.value[i] = valueGUIs[i].Show();
            }
        }

        protected bool CheckValueGUIsUpdate()
        {
            int valueCount = base.value.Count;

            if (base.value.Count == this.valueGUIs.Length)
            {
                return false;
            }

            for (int i = 0; i < valueCount; i++)
            {
                this.valueGUIs[i] = GenerateValueGUI();
            }

            return true;
        }

        protected abstract ValueGUI<T> GenerateValueGUI();

        #endregion Method
    }
}