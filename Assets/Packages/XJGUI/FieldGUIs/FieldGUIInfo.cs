using System;

namespace XJGUI
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FieldGUIInfo : Attribute
    {
        #region Property

        public bool   Hide       { get; set; } = false;
        public bool   IPv4       { get; set; } = false;
        public string Title      { get; set; } = null;
        public float  FieldWidth { get; set; } = -1;
        public float  MinValue   { get; set; } = float.NaN;
        public float  MaxValue   { get; set; } = float.NaN;
        public int    Decimals   { get; set; } = -1;

        public bool HideIsSet       { get { return this.Hide;                   } }
        public bool IPv4IsSet       { get { return this.IPv4IsSet;              } }
        public bool TitleIsSet      { get { return this.Title != null;          } }
        public bool FieldWidthIsSet { get { return this.FieldWidth >= 0;        } }
        public bool MinValueIsSet   { get { return !float.IsNaN(this.MinValue); } }
        public bool MaxValueIsSet   { get { return !float.IsNaN(this.MaxValue); } }
        public bool DecimalsIsSet   { get { return this.Decimals >= 0;          } }

        #endregion Property
    }
}