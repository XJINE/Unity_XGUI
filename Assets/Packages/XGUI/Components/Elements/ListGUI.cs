using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace XGUI
{
    public class ListGUI<TList, TElement, TGUI>  : ElementGUI<TList>
                                  where TList    : IList<TElement>
                                  where TElement : new()
                                  where TGUI     : ElementGUI<TElement>, new()
    {
        #region Field

        private readonly ScrollPanel _scrollPanel = new ();
        private readonly List<TGUI>  _guiList     = new ();

        public bool Reorderable = true;
        public bool Resizable   = true;

            #endregion Field

        #region Property

        public float Width
        {
            get => _scrollPanel.Width;
            set => _scrollPanel.Width = value;
        }
        
        public float Height
        {
            get => _scrollPanel.Height;
            set => _scrollPanel.Height = value;
        }

        public float MinWidth
        {
            get => _scrollPanel.MinWidth;
            set => _scrollPanel.MinWidth = value;
        }

        public float MinHeight
        {
            get => _scrollPanel.MinHeight;
            set => _scrollPanel.MinHeight = value;
        }

        public float MaxWidth
        {
            get => _scrollPanel.MaxWidth;
            set => _scrollPanel.MaxWidth = value;
        }

        public float MaxHeight
        {
            get => _scrollPanel.MaxHeight;
            set => _scrollPanel.MaxHeight = value;
        }

        #endregion Property

        #region Constructor

        public ListGUI() { }

        public ListGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override TList Show(TList value)
        {
            var valueCount = value.Count;
            var guisCount  = _guiList.Count;

            while (valueCount < guisCount)
            {
                guisCount -= 1;
                _guiList.RemoveAt(guisCount);
            }

            while (valueCount > guisCount)
            {
                guisCount += 1;
                _guiList.Add(new TGUI());
            }

            var addList    = new List<int>();
            var removeList = new List<int>();

            _scrollPanel.Show(() =>
            {
                for (var i = 0; i < valueCount; i++)
                {
                    XGUILayout.HorizontalLayout(() =>
                    {
                        GUILayout.FlexibleSpace(); // To Align Right

                        GUI.enabled = i > 0 && Reorderable;
                        if (GUILayout.Button("∧", GUILayout.Width(30)))
                        {
                            (value[i], value[i - 1]) = (value[i - 1], value[i]);
                        }

                        GUI.enabled = i < valueCount - 1 && Reorderable;
                        if (GUILayout.Button("∨", GUILayout.Width(30)))
                        {
                            (value[i], value[i + 1]) = (value[i + 1], value[i]);
                        }

                        GUI.enabled = Resizable;

                        if (GUILayout.Button("+", GUILayout.Width(30))) { addList   .Add(i); }
                        if (GUILayout.Button("-", GUILayout.Width(30))) { removeList.Add(i); }

                        GUI.enabled = true;
                    });

                    // NOTE:
                    // Just pass an index. Leave how to deal it to end GUI.
                    _guiList[i].Title = i + " :";

                    value[i] = _guiList[i].Show(value[i]);
                }
            });

            foreach (var i in addList)
            {
                using (var memoryStream = new MemoryStream()) // Deep copy.
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(memoryStream, value[i]);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    value.Insert(i, (TElement)binaryFormatter.Deserialize(memoryStream));
                }
                // value.Add(new TElement());
            }

            foreach (var i in removeList)
            {
                value.RemoveAt(i);
            }

            return value;
        }

        #endregion Method
    }
}