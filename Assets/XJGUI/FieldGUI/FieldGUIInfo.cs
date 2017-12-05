using System;

namespace XJGUI
{
    public class FieldGUIInfo : Attribute
    {
        #region Property

        public bool HideInGUI { get; set; }

        public string Title { get; set; }

        public bool BoldTitle { get; set; }

        public string[] Labels { get; set; }

        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public bool IPv4 { get; set; }

        public string FoldoutTitle { get; set; }

        public bool FoldoutClear { get; set; }

        #endregion Property
    }
}