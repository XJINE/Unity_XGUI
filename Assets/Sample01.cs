using UnityEngine;
using XGUI;

public class Sample01 : MonoBehaviour
{
    // NOTE:
    // Various GUI and Panels.

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
    public Color      colorValue;
    public Matrix4x4  matrixValue;
    public CameraType enumValue;

    private readonly BoolGUI             _boolGUI       = new ("Bool"        );
    private readonly StringGUI           _stringGUI     = new ("String"      ) { Width = 250 };
    private readonly IntGUI              _intGUI        = new ("Int"         ) {MinValue = 0, MaxValue = 100};
    private readonly FloatGUI            _floatGUI      = new ("Float", -1, 1);
    private readonly Vector2GUI          _vector2GUI    = new ("Vector2", Vector2.one, Vector2.one *3) { Digits = 1 };
    private readonly Vector3GUI          _vector3GUI    = new ("Vector3"     ) { MinValue = Vector3.zero };
    private readonly Vector4GUI          _vector4GUI    = new ("Vector4"     ) { Slider = false };
    private readonly Vector2IntGUI       _vector2IntGUI = new ("Vector2Int"  );
    private readonly Vector3IntGUI       _vector3IntGUI = new ("Vector3Int", Vector3Int.zero, Vector3Int.one);
    private readonly ColorGUI            _colorGUI      = new ("Color"       );
    private readonly Matrix4x4GUI        _matrixGUI     = new ("Matrix4x4"   );
    private readonly EnumGUI<CameraType> _enumGUI       = new ("Enum"        );

    private readonly FlexWindow   _window       = new ("Window Title");
    private readonly TabPanel     _tabPanel     = new ();
    private readonly FoldoutPanel _foldoutPanel = new ("Click to Open/Close");
    private readonly ScrollPanel  _scrollPanel  = new ();

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
                _foldoutPanel.Show(() =>
                {
                    vector2Value = _vector2GUI.Show(vector2Value);
                    vector3Value = _vector3GUI.Show(vector3Value);
                    vector4Value = _vector4GUI.Show(vector4Value);
                });

                vector2IntValue = _vector2IntGUI.Show(vector2IntValue);
                vector3IntValue = _vector3IntGUI.Show(vector3IntValue);

                matrixValue = _matrixGUI.Show(matrixValue);
            }),
            ("Others", () =>
            {
                colorValue = _colorGUI.Show(colorValue);
                enumValue  = _enumGUI.Show(enumValue);

                _scrollPanel.Show(() =>
                {
                    GUILayout.Box("BOX", GUILayout.Width(300), GUILayout.Height(300));

                    XGUILayout.Label("Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                   + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                   + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text",
                                      XGUILayout.LabelOption.NoWrap
                                    | XGUILayout.LabelOption.Bold);
                });
            }));
        });
    }

    #endregion Method
}