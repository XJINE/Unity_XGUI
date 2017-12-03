using UnityEngine;

namespace XJGUI
{
    public class Toolbar : AbstractGUI<int>
    {
        #region Property

        public string[] Labels { get; set; }

        #endregion Property

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

                base.value = GUILayout.Toolbar(base.value, this.Labels);
            });

            return base.value;
        }

        #endregion Method
    }
}