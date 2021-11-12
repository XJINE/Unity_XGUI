using System.Collections.Generic;
using UnityEngine;
using XGUI;

public class Sample03 : MonoBehaviour
{
    #region Field

    public CameraType  enumSelect;
    public float       floatListSelect;
    public List<float> floatListValue = new () { 0, 1.414f, 2.236f, 3.141f };
    public string      stringArraySelect;
    public string[]    stringArrayValue = { "Alpha", "Bravo", "Charlie",
                                            "Delta", "Echo",  "Foxtrot",
                                            "Golf",  "Hotel", "India",
                                            "Juliet" };

    private readonly FlexWindow _window = new ("Sample03");

    #endregion Field

    #region Method

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _window.IsVisible = !_window.IsVisible;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Press [Return] to show/hide window.");

        _window.Show(() =>
        {
            XGUILayout.HorizontalLayout(() =>
            {
                XGUILayout.Label("LabelText(Bold)", XGUILayout.LabelOption.Bold);
                XGUILayout.Label("LabelText");
            });
            
            XGUILayout.Label("SelectionGrid : Enum");
            enumSelect        = XGUILayout.SelectionGrid(enumSelect);
            XGUILayout.Label("SelectionGrid : List<Float>");
            floatListSelect   = XGUILayout.SelectionGrid(floatListSelect, floatListValue, 3);
            XGUILayout.Label("SelectionGrid : string[]");
            stringArraySelect = XGUILayout.SelectionGrid(stringArraySelect, stringArrayValue, 5);
        });
    }

    #endregion Method
}