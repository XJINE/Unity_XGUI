using System;

namespace XJGUI
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GUIAttribute : Attribute
    {
        #region Property

        public bool   Hide  { get; set; } = false;
        public bool   IPv4  { get; set; } = false;
        public string Title { get; set; } = null;
        public float  Width { get; set; } = float.NaN;

        #endregion Property
    }
}

Remote IPv4
Refactor Make Reflection GUI.