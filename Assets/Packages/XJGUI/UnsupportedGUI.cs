﻿namespace XJGUI
{
    public class UnSupportedGUI : Element<int>
    {
        #region Constructor

        public UnSupportedGUI() : base() { }

        public UnSupportedGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override int Show(int value)
        {
            XJGUILayout.Label("UnSupported : " + base.Title);
            return -1;
        }

        #endregion Method
    }
}