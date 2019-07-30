using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
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

            this.ElementType = TypeInfo.GetTypeInfo(typeof(T));

            TypeInfo childElementType = TypeInfo.GetTypeInfo(this.ElementType.type);

            this.ElementType.isIList = childElementType.isIList ? true : false;

            this.ElementType.type = childElementType.isIList
                                  ? this.ElementType.type
                                  : childElementType.type;
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
                        this.guis.Add(GenerateGUI(this.ElementType));
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

        protected virtual object GenerateGUI(TypeInfo typeInfo)
        {
            if (typeInfo.isIList)
            {
                return Activator.CreateInstance(typeof(IListGUI<>).MakeGenericType(typeInfo.type));
            }
            else
            {
                     if (typeInfo.type == typeof(bool))       { return new BoolGUI();       }
                else if (typeInfo.type == typeof(int))        { return new IntGUI();        }
                else if (typeInfo.type == typeof(float))      { return new FloatGUI();      }
                else if (typeInfo.type == typeof(Vector2))    { return new Vector2GUI();    }
                else if (typeInfo.type == typeof(Vector3))    { return new Vector3GUI();    }
                else if (typeInfo.type == typeof(Vector4))    { return new Vector4GUI();    }
                else if (typeInfo.type == typeof(Vector2Int)) { return new Vector2IntGUI(); }
                else if (typeInfo.type == typeof(Vector3Int)) { return new Vector3IntGUI(); }
                else if (typeInfo.type == typeof(Color))      { return new ColorGUI();      }
                else if (typeInfo.type == typeof(Matrix4x4))  { return new Matrix4x4GUI();  }
                else if (typeInfo.type == typeof(string))     { return new StringGUI();     }
                else if (typeInfo.type.IsEnum)
                {
                    return Activator.CreateInstance(typeof(EnumGUI<>).MakeGenericType(typeInfo.type));
                }
                else
                {
                    return Activator.CreateInstance(typeof(FieldGUI<>).MakeGenericType(typeInfo.type));
                }
            }
        }

        #endregion Method
    }
}