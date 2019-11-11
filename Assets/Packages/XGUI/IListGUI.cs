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
            get => this.panel.Title;
            set => this.panel.Title = value;
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

            this.ElementType   = TypeInfo.GetTypeInfo(typeof(T));
            TypeInfo childType = TypeInfo.GetTypeInfo(this.ElementType.type);

            this.ElementType.type    = childType.isIList ? this.ElementType.type : childType.type;
            this.ElementType.isIList = childType.isIList;
        }

        public override T Show(T value)
        {
            this.panel.Show(() =>
            {
                IList values = value != null ? (IList)value : null;
                int valuesCount = values != null ? values.Count : 0;
                int guisCount = this.guis.Count;
                int countDiff = guisCount - valuesCount;

                if (valuesCount == 0)
                {
                    GUILayout.Label("No Element");
                    return;
                }

                if (0 < countDiff)
                {
                    this.guis.RemoveRange(guisCount - 1 - countDiff, countDiff);
                }
                else
                {
                    for (int i = 0; i < -countDiff; i++)
                    {
                        this.guis.Add(ReflectionHelper.Generate(this.ElementType));
                    }
                }

                Type         type          = null;
                PropertyInfo titleProperty = null;
                MethodInfo   showMethod    = null;

                if (0 < valuesCount)
                {
                    type          = this.guis[0].GetType();
                    titleProperty = type.GetProperty("Title");
                    showMethod    = type.GetMethod("Show");
                }

                for (int i = 0; i < valuesCount; i++)
                {
                    titleProperty.SetValue(this.guis[i], "Element " + i);
                    values[i] = showMethod.Invoke(this.guis[i], new object[] { values[i] });
                }
            });

            return value;
        }

        #endregion Method
    }
}