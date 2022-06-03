using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public abstract class ListBaseGUI<TElement, TList> : ElementGUI<TList>
                                           where TList : IList<TElement>
    {
        #region Field

        protected const float ButtonWidth = 30;

        protected readonly FoldoutPanel _foldoutPanel = new ();
        protected readonly ScrollPanel  _scrollPanel  = new ();
        protected readonly List<(ElementGUI<TElement> gui, FoldoutPanel foldOutPanel)> _guiList = new ();

        public bool FoldoutList = true;
        public bool Reorderable = true;
        public bool Resizable   = true;
        public bool BoxSkin     = true;

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

        protected ListBaseGUI() { }

        protected ListBaseGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override TList Show(TList value)
        {
            var valueCount = value == null ? 0 : value.Count;
            var guiCount   = _guiList.Count;

            while (valueCount < guiCount)
            {
                guiCount -= 1;
                _guiList.RemoveAt(guiCount);
            }

            while (valueCount > guiCount)
            {
                guiCount += 1;
                _guiList.Add((GenerateGUI(), new FoldoutPanel()));
            }

            var addList    = new List<int>();
            var removeList = new List<int>();

            var panelAction = new Action(() =>
            {
                if (valueCount == 0)
                {
                    // NOTE:
                    // Show dummy buttons to keep UI layout.

                    XGUILayout.HorizontalLayout(() =>
                    {
                        GUILayout.Label("No Element");
                        GUILayout.FlexibleSpace(); // To Align Right

                        GUI.enabled = false;
                        GUILayout.Button("∧", GUILayout.Width(ButtonWidth));
                        GUILayout.Button("∨", GUILayout.Width(ButtonWidth));
                        if (!typeof(TList).IsArray)
                        {
                            GUI.enabled = Resizable;
                            if (GUILayout.Button("+", GUILayout.Width(ButtonWidth)))
                            {
                                addList.Add(0);
                            }
                            GUI.enabled = false;
                            GUILayout.Button("-", GUILayout.Width(ButtonWidth));
                        }
                        GUI.enabled = true;
                    });
                }
                else
                {
                    for (var i = 0; i < valueCount; i++)
                    {
                        var (gui, foldoutPanel) = _guiList[i];

                        foldoutPanel.Title = i + " : " + GetElementTitle(value[i], gui);
                        foldoutPanel.ButtonFieldAction = () =>
                        {
                            XGUILayout.HorizontalLayout(() =>
                            {
                                GUILayout.FlexibleSpace(); // To Align Right

                                GUI.enabled = i > 0 && Reorderable;
                                if (GUILayout.Button("∧", GUILayout.Width(ButtonWidth)))
                                {
                                    (value[i], value[i - 1]) = (value[i - 1], value[i]);
                                }

                                GUI.enabled = i < valueCount - 1 && Reorderable;
                                if (GUILayout.Button("∨", GUILayout.Width(ButtonWidth)))
                                {
                                    (value[i], value[i + 1]) = (value[i + 1], value[i]);
                                }

                                if (!typeof(TList).IsArray)
                                {
                                    GUI.enabled = Resizable;
                                    if (GUILayout.Button("+", GUILayout.Width(ButtonWidth))) { addList   .Add(i); }
                                    if (GUILayout.Button("-", GUILayout.Width(ButtonWidth))) { removeList.Add(i); }
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

            // CAUTION:
            // string.IsNullOrEmpty needs to consider nested list/array.

            if (FoldoutList && !string.IsNullOrEmpty(Title))
            {
                _foldoutPanel.Title = Title;
                _scrollPanel .Title = null;

                _foldoutPanel.BoxSkin = BoxSkin;
                _scrollPanel.BoxSkin  = false;

                _foldoutPanel.Show(() =>
                {
                    _scrollPanel.Show(panelAction);
                });
            }
            else
            {
                _scrollPanel.BoxSkin = BoxSkin;
                _scrollPanel.Title   = Title;

                _scrollPanel.Show(panelAction);
            }

            // NOTE:
            // Array type can't add or remove value now.
            // Because it makes code more complicated.
            // The reference of the instance will be changed.
            // If the length of the value must be changed, it should be defined as list.

            foreach (var i in addList)
            {
                // NOTE:
                // It is hard to implement to copy instance.
                // 1) Using BinaryFormatter and De/serialize is now deprecated.
                // And it requires serializable(System.Serializable) to the instance.
                // That's nonsense.
                // 2) It can't guarantee that generating the deep-copy instance is safe.

                // NOTE:
                // Remove limitation of TElement now. Because Array-type might be set.
                // ex. where TElement : new()

                var elementType = typeof(TElement);
                var newInstance = (TElement)(elementType.IsArray ? Array.CreateInstance(elementType.GetElementType(), 0)
                                                                 : Activator.CreateInstance(elementType));

                value.Insert(i == 0 ? i : i + 1, newInstance);
            }

            foreach (var i in removeList)
            {
                value.RemoveAt(i);
            }

            Updated = Updated || addList.Count != 0 || removeList.Count != 0;

            return value;
        }

        protected abstract ElementGUI<TElement> GenerateGUI();
        protected abstract string GetElementTitle(TElement value, ElementGUI<TElement> gui);

        #endregion Method
    }
}
