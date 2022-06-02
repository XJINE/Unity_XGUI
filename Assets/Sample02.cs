using System.Collections.Generic;
using UnityEngine;
using XGUI;

public class Sample02 : MonoBehaviour
{
    #region Field

    public int[]            intArrayValue;
    public Vector2[]        vectorArrayValue;
    public List<CameraType> enumListValue;
    public List<int[]>      intArrayListValue = new () {new []{ 1, 2, 3 }, new []{ 4, 5, 6 }};

    private readonly FlexWindow _window = new ("Sample02");

    private readonly FlexListGUI<int, int[]> _intArrayGUI = new ("IntArrayGUI")
    {
        MinHeight = 300,
    };

    private readonly FlexListGUI<Vector2, Vector2[]> _vectorArrayGUI = new ("VectorArrayGUI")
    {
        MinValue = Vector2.zero,
        MaxValue = Vector2.one * 10,
        Digits   = 1,
        Height   = 300
    };

    private readonly FlexListGUI<CameraType, List<CameraType>> _enumListGUI = new ("EnumListGUI")
    {
        MinHeight = 200
    };

    private readonly FlexListGUI<int[], List<int[]>> _intArrayListGUI = new ("IntArrayListGUI")
    {
        MinValue  = -1,
        MaxValue  = 999,
        MinHeight = 300,
    };

    private readonly FoldoutPanel _foldoutIntArrayListGUI = new("IntArrayListValue");

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
            _intArrayGUI    .Show(intArrayValue);
            _vectorArrayGUI .Show(vectorArrayValue);
            _enumListGUI    .Show(enumListValue);
            _intArrayListGUI.Show(intArrayListValue);

            _foldoutIntArrayListGUI.Show(() =>
            {
                foreach (var intArray in intArrayListValue)
                {
                    foreach (var intValue in intArray)
                    {
                        XGUILayout.Label(intValue.ToString());
                    }
                }
            });
        });
    }

    #endregion Method
}