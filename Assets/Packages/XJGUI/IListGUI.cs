using System;
using System.Collections;
using System.Collections.Generic;
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

        protected Type ElementType { get; private set; }

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
            base.Initialize();
            this.ElementType = GetElementType();
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
                    GUILayout.Label("NO ELEMENT");
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
                        var gui = GenerateGUI();
                        this.guis.Add(GenerateGUI());
                    }
                }

                for (int i = 0; i < valuesCount; i++)
                {
                    values[i] = this.guis[i].GetType().GetMethod("Show")
                               .Invoke(this.guis[i], new object[] { values[i] });
                }
            });

            return value;
        }

        protected virtual object GenerateGUI()
        {
                 if(this.ElementType == typeof(bool))       { return new BoolGUI();       }
            else if(this.ElementType == typeof(int))        { return new IntGUI();        }
            else if(this.ElementType == typeof(float))      { return new FloatGUI();      }
            else if(this.ElementType == typeof(Vector2))    { return new Vector2GUI();    }
            else if(this.ElementType == typeof(Vector3))    { return new Vector3GUI();    }
            else if(this.ElementType == typeof(Vector4))    { return new Vector4GUI();    }
            else if(this.ElementType == typeof(Vector2Int)) { return new Vector2IntGUI(); }
            else if(this.ElementType == typeof(Vector3Int)) { return new Vector3IntGUI(); }
            else if(this.ElementType == typeof(Color))      { return new ColorGUI();      }
            else if(this.ElementType == typeof(Matrix4x4))  { return new Matrix4x4GUI();  }
            else if(this.ElementType == typeof(string))     { return new StringGUI();     }
            else
            {
                return Activator.CreateInstance(typeof(FieldGUI<>).MakeGenericType(this.ElementType));
            }
        }

        private static Type GetElementType()
        {
            Type type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                Type[] types = type.GetGenericArguments();

                if (types.Length == 1)
                {
                    type = types[0];
                }
            }

            return type;
        }

        #endregion Method
    }
}