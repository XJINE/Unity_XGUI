using System;
using System.Collections.Generic;

namespace XGUI
{
    public abstract class SelectionElement<T> : Component<T>
    {
        #region Property

        protected Type Type { get; private set; }

        #endregion Property

        #region Constructor

        public SelectionElement() : base() { }

        public SelectionElement(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            this.Type = typeof(T);
        }

        public abstract T Show(T value, IList<T> values);

        #endregion Method
    }
}