using System.Collections.Generic;
using UnityEngine;
using XGUI;

public class Sample04 : MonoBehaviour
{
    #region Field

    public bool       boolValue;
    public string     stringValue;
    public int        intValue;
    public float      floatValue;
    public Vector2    vector2Value;
    public Vector3    vector3Value;
    public Vector4    vector4Value;
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;
    public Matrix4x4  matrixValue;
    public Color      colorValue;
    public CameraType enumValue;

    public int[]         intArrayValue;
    public List<Vector2> vectorListValue;
    public List<float[]> floatArrayListValue = new ()
    {
        new []{ -1f, -2f, -3.141592f },
        new []{  1f,  2f,  3.141592f }
    };

    private readonly FlexGUI<bool>       _boolGUI       = new ("Bool"        );
    private readonly FlexGUI<string>     _stringGUI     = new ("String"      ) { Width = 250 };
    private readonly FlexGUI<int>        _intGUI        = new ("Int"         ) { MinValue = 0, MaxValue = 100 };
    private readonly FlexGUI<float>      _floatGUI      = new ("Float", -1, 1);
    private readonly FlexGUI<Vector2>    _vector2GUI    = new ("Vector2", Vector2.one, Vector2.one *3) { Digits = 1 };
    private readonly FlexGUI<Vector3>    _vector3GUI    = new ("Vector3"     ) { MinValue = Vector3.zero };
    private readonly FlexGUI<Vector4>    _vector4GUI    = new ("Vector4"     ) { Slider = false };
    private readonly FlexGUI<Vector2Int> _vector2IntGUI = new ("Vector2Int"  );
    private readonly FlexGUI<Vector3Int> _vector3IntGUI = new ("Vector3Int", Vector3Int.zero, Vector3Int.one);
    private readonly FlexGUI<Matrix4x4>  _matrixGUI     = new ("Matrix4x4"   );
    private readonly FlexGUI<Color>      _colorGUI      = new ("Color"       );
    private readonly FlexGUI<CameraType> _enumGUI       = new ("Enum"        );
    
    private readonly FlexGUI<int[]> _intArrayGUI = new ("IntArray")
    {
        MinValue = -1,
        MaxValue = 10
    };
    private readonly FlexGUI<List<Vector2>> _vectorListGUI = new ("VectorList")
    {
        MinValue = 0, Digits = 1
    };
    private readonly FlexGUI<List<float[]>> _floatArrayListGUI = new("FloatArrayList")
    {
        MinValue = -10,
        MaxValue = 10,
        Digits   = 2,
        Height   = 300
    };
    
    private readonly FlexWindow _window   = new ("Sample04");
    private readonly TabPanel   _tabPanel = new ();

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
            _tabPanel.Show
            (("Basic", () =>
            {
                boolValue   = _boolGUI  .Show(boolValue);
                stringValue = _stringGUI.Show(stringValue);
                intValue    = _intGUI   .Show(intValue);
                floatValue  = _floatGUI .Show(floatValue);
            }),
            ("Vector & Matrix", () =>
            {
                vector2Value = _vector2GUI.Show(vector2Value);
                vector3Value = _vector3GUI.Show(vector3Value);
                vector4Value = _vector4GUI.Show(vector4Value);
        
                vector2IntValue = _vector2IntGUI.Show(vector2IntValue);
                vector3IntValue = _vector3IntGUI.Show(vector3IntValue);
        
                matrixValue = _matrixGUI.Show(matrixValue);
            }),
            ("Others", () =>
            {
                colorValue = _colorGUI.Show(colorValue);
                enumValue  = _enumGUI.Show(enumValue);
            }),
            ("Array", () =>
            {
                _intArrayGUI.Show(intArrayValue);
                _vectorListGUI.Show(vectorListValue);
                _floatArrayListGUI.Show(floatArrayListValue);
            }));
        });
    }

    #endregion Method
}