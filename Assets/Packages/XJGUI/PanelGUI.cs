using System;

namespace XJGUI
{
    public abstract class PanelGUI<T> : ComponentGUI<T>
    {
        public abstract T Show(params Action[] guiActions);
    }
}