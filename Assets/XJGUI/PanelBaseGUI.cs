using System;

namespace XJGUI
{
    public abstract class PanelBaseGUI<T> : BaseGUI<T>
    {
        public abstract T Show(params Action[] guiActions);
    }
}