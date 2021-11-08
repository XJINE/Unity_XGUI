using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XGUI
{
    public class IListGUI<T> : Element<T> where T : IList
    {
        #region Field

        protected List<object> guis = new List<object>();
        protected FoldoutPanel panel = new FoldoutPanel();

        #endregion Field

        #region Property

        protected TypeInfo ElementType { get; private set; }

        public override string Title
        {
            get => panel.Title;
            set => panel.Title = value;
        }

        #endregion Property

        #region Constructor

        public IListGUI() : base() { }

        public IListGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            // NOTE:
            // T must be IList<>.

            base.Initialize();

            ElementType   = TypeInfo.GetTypeInfo(typeof(T));
            var childType = TypeInfo.GetTypeInfo(ElementType.Type);

            ElementType.Type    = childType.IsIList ? ElementType.Type : childType.Type;
            ElementType.IsIList = childType.IsIList;
        }

        public override T Show(T value)
        {
            panel.Show(() =>
            {
                var values      = value  != null ? (IList)value : null;
                var valuesCount = values != null ? values.Count : 0;
                var guisCount   = guis.Count;
                var countDiff   = guisCount - valuesCount;

                if (valuesCount == 0)
                {
                    GUILayout.Label("No Element");
                    return;
                }

                if (0 < countDiff)
                {
                    guis.RemoveRange(guisCount - 1 - countDiff, countDiff);
                }
                else
                {
                    for (var i = 0; i < -countDiff; i++)
                    {
                        guis.Add(ReflectionHelper.Generate(this.ElementType));
                    }
                }

                Type         type          = null;
                PropertyInfo titleProperty = null;
                MethodInfo   showMethod    = null;

                if (0 < valuesCount)
                {
                    type          = guis[0].GetType();
                    titleProperty = type.GetProperty("Title");
                    showMethod    = type.GetMethod("Show");
                }

                for (var i = 0; i < valuesCount; i++)
                {
                    titleProperty.SetValue(guis[i], "Element " + i);
                    values[i] = showMethod.Invoke(guis[i], new object[] { values[i] });
                }
            });

            return value;
        }

        #endregion Method
    }
}