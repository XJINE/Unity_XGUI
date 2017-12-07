using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Method

    public static void HorizontalLayout(Action guiAction)
    {
        GUILayout.BeginHorizontal();
        {
            guiAction();
        }
        GUILayout.EndHorizontal();
    }

    public static void VerticalLayout(Action guiAction)
    {
        GUILayout.BeginVertical();
        {
            guiAction();
        }
        GUILayout.EndVertical();
    }

    #endregion Method
}