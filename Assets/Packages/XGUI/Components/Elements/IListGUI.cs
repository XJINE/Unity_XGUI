using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public class IListGUI<TItem, TList> : ElementGUI<TList> where TList : IList<TItem>
    {
        #region Field

        private readonly List<ElementGUI<TItem>> _guis  = new ();
        private readonly FoldoutPanel _foldoutPanel = new ();
        private readonly ScrollPanel  _scrollPanel  = new ();

        #endregion Field

        #region Property

        protected TypeInfo ElementType { get; private set; }

        public override string Title
        {
            get => _foldoutPanel.Title;
            set => _foldoutPanel.Title = value;
        }

        public float Height
        {
            get => _scrollPanel.Height;
            set => _scrollPanel.Height = value;
        }

        public float MinHeight
        {
            get => _scrollPanel.MinHeight;
            set => _scrollPanel.MinHeight = value;
        }

        public float MaxHeight
        {
            get => _scrollPanel.MaxHeight;
            set => _scrollPanel.MaxHeight = value;
        }

        #endregion Property

        #region Constructor

        public IListGUI() { }

        public IListGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            ElementType   = TypeInfo.GetTypeInfo(typeof(TList));
            var childType = TypeInfo.GetTypeInfo(ElementType.Type);

            ElementType.Type    = childType.IsIList ? ElementType.Type : childType.Type;
            ElementType.IsIList = childType.IsIList;
        }

        public override TList Show(TList values)
        {
            _foldoutPanel.Show(() =>
            {
                _scrollPanel.Show(() =>
                {
                    var valuesCount = values != null ? values.Count : 0;
                    var guisCount   = _guis.Count;
                    var countDiff   = guisCount - valuesCount;

                    if (valuesCount == 0)
                    {
                        GUILayout.Label("No Element");
                        return;
                    }

                    if (0 < countDiff)
                    {
                        _guis.RemoveRange(guisCount - 1 - countDiff, countDiff);
                    }
                    else
                    {
                        for (var i = 0; i < -countDiff; i++)
                        {
                            var gui = (ElementGUI<TItem>) ReflectionHelper.GenerateGUI(ElementType);
                            gui.Title = "Element " + (guisCount + i);
                            _guis.Add(gui);
                        }
                    }

                    for (var i = 0; i < valuesCount; i++)
                    {
                        values[i] = _guis[i].Show(values[i]);
                    }
                });

            });

            return values;
        }

        #endregion Method
    }
}