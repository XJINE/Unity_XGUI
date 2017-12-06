using System;

namespace XJGUI
{
    public abstract class PanelBaseGUI<T> : ComponentBaseGUI<T>
    {
        public abstract T Show(params Action[] guiActions);
    }
}