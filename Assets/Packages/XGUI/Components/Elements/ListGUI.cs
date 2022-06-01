using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public class ListGUI<TElement, TList, TGUI>  : ElementGUI<TList>
                                  where TElement : new()
                                  where TList    : IList<TElement>
                                  where TGUI     : ElementGUI<TElement>, new()
    {
        #region Field

        private readonly FoldoutPanel _foldoutPanel = new ();
        private readonly ScrollPanel  _scrollPanel  = new ();
        private readonly List<(TGUI, FoldoutPanel)> _guiList = new ();

        public bool FoldoutList = true;
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
                _guiList.Add((new TGUI(), new FoldoutPanel()));
            }

            var addList    = new List<int>();
            var removeList = new List<int>();

            var panelAction = new Action(() =>
            {
                if (valueCount == 0)
                {
                    GUILayout.Label("No Element");
                }
                else
                {
                    for (var i = 0; i < valueCount; i++)
                    {
                        var (gui, foldoutPanel) = _guiList[i];

                        // NOTE:
                        // Just pass an index. Leave how to deal it to end GUI.

                        foldoutPanel.Title = i + " : " + (string.IsNullOrWhiteSpace(gui.Title) ? "Element" : gui.Title);
                        foldoutPanel.ButtonFieldAction = () =>
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

                                if (!typeof(TList).IsArray)
                                {
                                    GUI.enabled = Resizable;
                                    if (GUILayout.Button("+", GUILayout.Width(30))) { addList   .Add(i); }
                                    if (GUILayout.Button("-", GUILayout.Width(30))) { removeList.Add(i); }
                                }

                                GUI.enabled = true;
                            });
                        };
                        foldoutPanel.Show(() =>
                        {
                            value[i] = gui.Show(value[i]);
                            Updated = Updated || gui.Updated;
                        });
                    }
                }
            });

            if (FoldoutList)
            {
                _foldoutPanel.Title = Title;
                _scrollPanel .Title = null;

                _foldoutPanel.Show(() =>
                {
                    _scrollPanel.Show(panelAction);
                });
            }
            else
            {
                _scrollPanel.Title = Title;
                _scrollPanel.Show(panelAction);
            }

            foreach (var i in addList)
            {
                // NOTE:
                // It is hard to implement to copy instance.
                // 1) Using BinaryFormatter and De/serialize is now deprecated.
                // And it requires serializable(System.Serializable) to the instance.
                // That's nonsense.
                // 2) It can't guarantee that generating the deep-copy instance is safe.

                value.Insert(i, new TElement());
            }

            foreach (var i in removeList)
            {
                value.RemoveAt(i);
            }

            Updated = Updated || addList.Count != 0 || removeList.Count != 0;

            return value;
        }

        #endregion Method
    }
}