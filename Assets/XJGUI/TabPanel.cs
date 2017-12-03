using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : PanelBaseGUI<int>
    {
        #region Property

        public string[] Labels { get; set; }

        #endregion Property

        #region Method

        public override int Show(params Action[] guiAction)
        {
            //if (functions.Length != this.labels.Length)
            //{
            //    throw new Exception(string.Format(ErrorMessage.DifferentDataLengthError, functions, this.labels));
            //}

            XJGUILayout.VerticalLayout((Action)(()=> 
            {
                base.ShowTitle();

                base.value = GUILayout.Toolbar(base.value, (string[])this.Labels);

                guiAction[base.value]();
            }));

            return base.value;
        }

        #endregion Method
    }
}