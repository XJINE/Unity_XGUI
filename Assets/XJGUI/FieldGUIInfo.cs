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

        public int Decimals { get; set; }

        public bool IPv4 { get; set; }

        public bool Toolbar { get; set; }

        public string FoldoutStart { get; set; }

        public bool FoldoutEnd { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUIInfo()
        {
            this.HideInGUI = false;
            this.Title     = null;
            this.BoldTitle = false;
            this.Labels    = null;
            this.MinValue  = float.MinValue;
            this.MaxValue  = float.MaxValue;
            this.Decimals  = 2;
            this.IPv4      = false;
            this.FoldoutStart = null;
            this.FoldoutEnd   = false;
        }

        #endregion constructor
    }
}