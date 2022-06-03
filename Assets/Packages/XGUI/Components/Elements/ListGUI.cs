using System.Collections.Generic;

namespace XGUI
{
    // NOTE:
    // Custom TGUI should be override Updated and Title property.

    public class ListGUI<TElement, TList, TGUI> : ListBaseGUI<TElement, TList>
                                    where TList : IList<TElement>
                                    where TGUI  : ElementGUI<TElement>, new()
    {
        #region Constructor

        public ListGUI() { }

        public ListGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override ElementGUI<TElement> GenerateGUI()
        {
            return new TGUI();
        }

        protected override string GetElementTitle(TElement value, ElementGUI<TElement> gui)
        {
            return string.IsNullOrEmpty(gui.Title) ? "Element" : gui.Title;
        }

        #endregion Method
    }
}