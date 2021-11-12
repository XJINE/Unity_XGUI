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

    // public List<CameraType>[] enumListArrayValue = new List<CameraType>[]
    // {
    //     new List<CameraType>() { CameraType.Game, CameraType.Reflection },
    //     new List<CameraType>() { CameraType.VR,   CameraType.SceneView  }
    // };
    //
    // public CameraType  enumSelect;
    // public float       floatListSelect;
    // public List<float> floatListValue = new List<float>() { 0, 1.414f, 2.236f, 3.141f };
    // public string      stringArraySelect;
    // public string[]    stringArrayValue = new string[] { "Alpha", "Bravo", "Charlie",
    //                                                      "Delta", "Echo",  "Foxtrot",
    //                                                      "Golf",  "Hotel", "India",
    //                                                      "Juliet" };

    private readonly FlexWindow _window   = new ("Window Title");

    private readonly IListGUI<int, int[]> _intArrayGUI = new ("IntArrayGUI")
    {
        // MinValue  = 0,
        // MaxValue  = 3,
        MinHeight = 200,
    };

    private readonly IListGUI<Vector2, Vector2[]> _vectorArrayGUI = new ("VectorArrayGUI")
    {
        MinValue  = Vector2.zero,
        MaxValue  = Vector2.one * 10,
        Digits    = 1,
        Height    = 200
    };

    private readonly IListGUI<CameraType, List<CameraType>> _enumListGUI = new ("EnumListGUI")
    {
        MinHeight = 80
    };

    private readonly IListGUI<int[], List<int[]>> _intArrayListGUI = new ("IntArrayListGUI")
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