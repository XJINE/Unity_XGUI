using System;
using UnityEngine;

namespace XJGUI
{
    public class TabPanel : PanelGUI<int>
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

                base.Value = GUILayout.Toolbar(base.Value, this.Labels);

                guiAction[base.Value]();
            }));

            return base.Value;
        }

        #endregion Method
    }
}