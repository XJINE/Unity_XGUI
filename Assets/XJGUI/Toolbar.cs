using UnityEngine;

namespace XJGUI
{
    public class Toolbar : AbstractGUI<int>
    {
        #region Field

        public string[] labels;

        #endregion Field

        #region Method

        public override int Show()
        {
            //if (this.labels == null ||this.labels.Length == 0)
            //{
            //    throw new Exception(string.Format(ErrorMessage.NullOrNoDataError, this.labels));
            //}

            XJGUILayout.VerticalLayout(()=> 
            {
                base.ShowTitle();

                base.value = GUILayout.Toolbar(base.value, this.labels);
            });

            return base.value;
        }

        #endregion Method
    }
}