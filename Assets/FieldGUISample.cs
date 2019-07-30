using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
{
    #region Field

    public bool   boolValue;
    public int    intValue;
    public string stringValue;
    [GUI(Hide = true)]
    public string hideValue;

    [Header("Vector")]

    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Vector4 vector4Value;
    [GUI(Title = "V2I")]
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;

    [Header("Others")]

    public Color     colorValue;
    public Matrix4x4 matrixValue;
    [GUI(Width = 300)]
    public CameraType cameraTypeA;
    public CameraType cameraTypeB;
    public UserStruct userStructValue;

    [Header("Array")]
    public int[] intArrayValue;
    public List<UserStruct> structListValue;

    private FlexWindow window;
    private FieldGUI<FieldGUISample> fieldGUI;

    #endregion Field

    #region Method

    private void Start()
    {
        this.window = new FlexWindow();
        this.fieldGUI = new FieldGUI<FieldGUISample>();
    }

    private void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show(this);
        });
    }

    #endregion Method
}