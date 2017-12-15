using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public abstract class ValuesGUI<T> : ElementGUI<IList<T>> where T : struct
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
            // NOTE:
            // base.title & base.boldTitle is initialized in base() constructor.

            this.foldOutPanel = new FoldoutPanel()
            {
                Title = base.title,
                BoldTitle = base.boldTitle,
                Value = false
            };

            // NOTE:
            // this.minValue & this.maxValue are initialized in inherit constructor.

            this.decimals = XJGUILayout.DefaultDecimals;
            this.textFieldWidth = XJGUILayout.DefaultTextFieldWidthValue;
            this.withSlider = XJGUILayout.DefaultWithSlider;
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

        public void SetValue(int index, T value)
        {
            // NOTE:
            // Almost for FieldGUISync.

            this.valueGUIs[index].Value = value;
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
                this.Value[i] = this.valueGUIs[i].Show();
            }
        }

        protected bool CheckValueGUIsUpdate()
        {
            // NOTE:
            // We have not to check if base.value is changed.
            // When "Value" property is changed, call this function.

            int valueCount = this.Value.Count;

            if (this.valueGUIs != null && this.valueGUIs.Length == this.Value.Count)
            {
                return false;
            }

            this.valueGUIs = new ValueGUI<T>[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                ValueGUI<T> gui = GenerateValueGUI();

                gui.Value = this.Value[i];
                gui.BoldTitle = false;
                gui.MinValue = this.MinValue;
                gui.MaxValue = this.MaxValue;
                gui.Decimals = this.Decimals;
                gui.TextFieldWidth = this.TextFieldWidth;
                gui.WithSlider = this.WithSlider;

                this.valueGUIs[i] = gui;
            }

            return true;
        }

        protected abstract ValueGUI<T> GenerateValueGUI();

        #endregion Method
    }
}