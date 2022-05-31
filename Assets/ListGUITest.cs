using System.Collections.Generic;
using UnityEngine;
using XGUI;

public class ListGUITest : MonoBehaviour
{
    public Vector2       vector2Value;
    public Vector2[]     vector2Array;
    public List<Vector2> vector2List;

    private FlexWindow window = new ()
    {
        MaxWidth  = 400,
        MaxHeight = 800,
    };

    private ListGUI<Vector2, Vector2[],     FlexGUI<Vector2>> vector2ArrayGUI = new ();
    private ListGUI<Vector2, List<Vector2>, FlexGUI<Vector2>> vector2ListGUI  = new ();

    private Vector2GUI _vector2GUI = new()
    {
        MinValue = Vector2.zero,
        MaxValue = Vector2.one
    };

    private void OnGUI()
    {
        window.Show(() =>
        {
            vector2Value = _vector2GUI    .Show(vector2Value);
            vector2Array = vector2ArrayGUI.Show(vector2Array);
            vector2List  = vector2ListGUI .Show(vector2List);
        });
    }
}