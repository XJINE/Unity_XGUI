using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    public static readonly GUIStyle BoldLabelStyle = new GUIStyle()
    {
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleLeft
    };

    #endregion Field

    #region Method

    public static void BoldLabel(string text)
    {
        GUILayout.Label(text, XJGUILayout.BoldLabelStyle);
    }

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