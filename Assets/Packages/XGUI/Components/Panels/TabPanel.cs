using System;
using UnityEngine;

namespace XGUI
{
    public class TabPanel : Panel<int>
    {
        #region Property

        private static GUIStyle _tabStyle;
        private static GUIStyle TabStyle
        {
            // NOTE:
            // GUIStyle is able to access only in OnGUI.
            get
            {
                if (_tabStyle != null)
                {
                    _tabStyle = new GUIStyle(GUI.skin.button);
                    _tabStyle.onNormal.background = Texture2D.blackTexture;
                }

                return _tabStyle;
            }
        }

        #endregion Property

        #region Constructor

        public TabPanel() { }

        public TabPanel(string title) { }

        #endregion Constructor

        #region Method

        public int Show(params (string label, Action show)[] tabActions)
        {
            var previousValue = Value;

            var labels = new string[tabActions.Length];

            for (var i = 0; i < labels.Length; i++)
            {
                labels[i] = tabActions[i].label;
            }

            ShowTitle();
            XGUILayout.VerticalLayout(() =>
            {
                Value = GUILayout.Toolbar(Value, labels, TabStyle);
                tabActions[Value].show();

            }, BoxSkin ? GUI.skin.box : null);

            Updated = previousValue != Value;

            return Value;
        }

        #endregion Method
    }
}