using System;

namespace XJGUI
{
    public abstract class Panel<T> : Component<T>
    {
        public abstract T Show(params Action[] show);
    }
}