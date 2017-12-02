using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : PanelBaseGUI <int>
    {
        #region Field

        public string[] labels;

        #endregion Field

        #region Method

        public override int Show(params Action[] guiAction)
        {
            //if (functions.Length != this.labels.Length)
            //{
            //    throw new Exception(string.Format(ErrorMessage.DifferentDataLengthError, functions, this.labels));
            //}

            XJGUILayout.VerticalLayout(()=> 
            {
                base.ShowTitle();

                base.value = GUILayout.Toolbar(base.value, this.labels);

                guiAction[base.value]();
            });

            return base.value;
        }

        #endregion Method
    }
}