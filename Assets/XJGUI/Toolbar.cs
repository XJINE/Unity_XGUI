using UnityEngine;

namespace XJGUI
{
    public class Toolbar : ComponentBaseGUI<int>
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

                base.Value = GUILayout.Toolbar(base.Value, this.Labels);
            });

            return base.Value;
        }

        #endregion Method
    }
}